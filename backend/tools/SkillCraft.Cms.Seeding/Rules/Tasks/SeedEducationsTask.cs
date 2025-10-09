using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Educations;
using SkillCraft.Cms.Core.Educations.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedEducationsTask : SeedingTask
{
  public override string? Description => "Seeds the Educations contents.";
}

internal class SeedEducationsTaskHandler : ICommandHandler<SeedEducationsTask, TaskResult>
{
  private readonly IEducationQuerier _educationQuerier;
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly IFeatureService _featureService;
  private readonly ILogger<SeedEducationsTaskHandler> _logger;

  public SeedEducationsTaskHandler(
    IEducationQuerier educationQuerier,
    IContentService contentService,
    DefaultSettings defaults,
    IFeatureService featureService,
    ILogger<SeedEducationsTaskHandler> logger)
  {
    _educationQuerier = educationQuerier;
    _contentService = contentService;
    _defaults = defaults;
    _featureService = featureService;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedEducationsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/educations.json", Encoding.UTF8, cancellationToken);
    EducationDto[] entities = SeedingSerializer.Deserialize<EducationDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Educations} education(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<EducationModel> results = await _educationQuerier.SearchAsync(new SearchEducationsPayload(), cancellationToken);
      Dictionary<Guid, EducationModel> educations = results.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Educations} education(s) from database.", educations.Count);

      foreach (EducationDto entity in entities)
      {
        _ = educations.TryGetValue(entity.Id, out EducationModel? education);
        if (education is null || HasChanges(education, entity))
        {
          if (entity.Feature is not null)
          {
            await _featureService.SeedAsync(entity.Feature, entity.Name, cancellationToken);
          }

          Content content;
          if (education is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Educations.ContentTypeId.ToString(),
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
              ?? throw new InvalidOperationException($"The education content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The education content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Education '{Education}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Education '{Education}' has no change.", education);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(EducationModel education, EducationDto entity) => education.Slug != entity.Slug
    || education.Name != entity.Name
    || education.WealthMultiplier != entity.WealthMultiplier
    || education.Skill?.Id != entity.Skill?.Id
    || education.Feature?.Name != entity.Feature?.Name
    || education.Feature?.Description != entity.Feature?.Description
    || education.Summary != entity.Summary
    || education.MetaDescription != entity.MetaDescription
    || education.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(EducationDto education)
  {
    List<FieldValuePayload> payloads = new(capacity: 3);
    if (education.WealthMultiplier.HasValue)
    {
      payloads.Add(new FieldValuePayload(Educations.WealthMultiplier.ToString(), education.WealthMultiplier.Value.ToString()));
    }
    if (education.Skill is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([education.Skill.Id]);
      payloads.Add(new FieldValuePayload(Educations.Skill.ToString(), value));
    }
    if (education.Feature is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([education.Feature.Id]);
      payloads.Add(new FieldValuePayload(Educations.Feature.ToString(), value));
    }
    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(EducationDto education)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Educations.Slug.ToString(), education.Slug)
    };
    if (!string.IsNullOrWhiteSpace(education.Summary))
    {
      payloads.Add(new FieldValuePayload(Educations.Summary.ToString(), education.Summary));
    }
    if (!string.IsNullOrWhiteSpace(education.Description))
    {
      payloads.Add(new FieldValuePayload(Educations.HtmlContent.ToString(), education.Description));
    }
    return payloads.AsReadOnly();
  }
}
