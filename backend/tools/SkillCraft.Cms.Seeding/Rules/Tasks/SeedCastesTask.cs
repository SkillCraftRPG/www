using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Castes;
using SkillCraft.Cms.Core.Castes.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedCastesTask : SeedingTask
{
  public override string? Description => "Seeds the Castes contents.";
}

internal class SeedCastesTaskHandler : ICommandHandler<SeedCastesTask, TaskResult>
{
  private readonly ICasteQuerier _casteQuerier;
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly IFeatureService _featureService;
  private readonly ILogger<SeedCastesTaskHandler> _logger;

  public SeedCastesTaskHandler(
    ICasteQuerier casteQuerier,
    IContentService contentService,
    DefaultSettings defaults,
    IFeatureService featureService,
    ILogger<SeedCastesTaskHandler> logger)
  {
    _casteQuerier = casteQuerier;
    _contentService = contentService;
    _defaults = defaults;
    _featureService = featureService;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedCastesTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/castes.json", Encoding.UTF8, cancellationToken);
    CasteDto[] entities = SeedingSerializer.Deserialize<CasteDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Castes} caste(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<CasteModel> castes = await _casteQuerier.SearchAsync(new SearchCastesPayload(), cancellationToken);
      Dictionary<Guid, CasteModel> castesById = castes.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Castes} caste(s) from database.", castesById.Count);

      foreach (CasteDto entity in entities)
      {
        _ = castesById.TryGetValue(entity.Id, out CasteModel? caste);
        if (caste is null || HasChanges(caste, entity))
        {
          if (entity.Feature is not null)
          {
            await _featureService.SeedAsync(entity.Feature, entity.Name, cancellationToken);
          }

          Content content;
          if (caste is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Castes.ContentTypeId.ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            payload.FieldValues.AddRange(GetInvariantFieldValues(entity));
            payload.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.CreateAsync(payload, cancellationToken);
          }
          else
          {
            SaveContentLocalePayload invariant = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name
            };
            invariant.FieldValues.AddRange(GetInvariantFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The caste content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The caste content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Caste '{Caste}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Caste '{Caste}' has no change.", caste);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(CasteModel caste, CasteDto entity) => caste.Slug != entity.Slug
    || caste.Name != entity.Name
    || caste.WealthRoll != entity.WealthRoll
    || caste.Skill?.Id != entity.Skill?.Id
    || caste.Feature?.Name != entity.Feature?.Name
    || caste.Feature?.Description != entity.Feature?.Description
    || caste.Summary != entity.Summary
    || caste.MetaDescription != entity.MetaDescription
    || caste.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(CasteDto caste)
  {
    List<FieldValuePayload> payloads = new(capacity: 3);
    if (!string.IsNullOrWhiteSpace(caste.WealthRoll))
    {
      payloads.Add(new FieldValuePayload(Castes.WealthRoll.ToString(), caste.WealthRoll));
    }
    if (caste.Skill is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([caste.Skill.Id]);
      payloads.Add(new FieldValuePayload(Castes.Skill.ToString(), value));
    }
    if (caste.Feature is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([caste.Feature.Id]);
      payloads.Add(new FieldValuePayload(Castes.Feature.ToString(), value));
    }
    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(CasteDto caste)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Castes.Slug.ToString(), caste.Slug)
    };
    if (!string.IsNullOrWhiteSpace(caste.Summary))
    {
      payloads.Add(new FieldValuePayload(Castes.Summary.ToString(), caste.Summary));
    }
    if (!string.IsNullOrWhiteSpace(caste.Description))
    {
      payloads.Add(new FieldValuePayload(Castes.HtmlContent.ToString(), caste.Description));
    }
    return payloads.AsReadOnly();
  }
}
