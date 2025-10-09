using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Skills;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedSkillsTask : SeedingTask
{
  public override string? Description => "Seeds the Skills contents.";
}

internal class SeedSkillsTaskHandler : ICommandHandler<SeedSkillsTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly ILogger<SeedSkillsTaskHandler> _logger;
  private readonly ISkillQuerier _skillQuerier;

  public SeedSkillsTaskHandler(
    IContentService contentService,
    DefaultSettings defaults,
    ILogger<SeedSkillsTaskHandler> logger,
    ISkillQuerier skillQuerier)
  {
    _contentService = contentService;
    _defaults = defaults;
    _logger = logger;
    _skillQuerier = skillQuerier;
  }

  public async Task<TaskResult> HandleAsync(SeedSkillsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/skills.json", Encoding.UTF8, cancellationToken);
    SkillDto[] entities = SeedingSerializer.Deserialize<SkillDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Skills} skill(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<SkillModel> results = await _skillQuerier.SearchAsync(new SearchSkillsPayload(), cancellationToken);
      Dictionary<Guid, SkillModel> skills = results.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Skills} skill(s) from database.", skills.Count);

      foreach (SkillDto entity in entities)
      {
        _ = skills.TryGetValue(entity.Id, out SkillModel? skill);
        if (skill is null || HasChanges(skill, entity))
        {
          Content content;
          if (skill is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Skills.ContentTypeId.ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Value.ToString(),
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
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name
            };
            invariant.FieldValues.AddRange(GetInvariantFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The skill content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The skill content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Skill '{Skill}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Skill '{Skill}' has no change.", skill);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(SkillModel skill, SkillDto entity) => skill.Slug != entity.Slug
    || skill.Name != entity.Name
    || skill.Attribute?.Id != entity.Attribute?.Id
    || skill.Value != entity.Value
    || skill.Summary != entity.Summary
    || skill.MetaDescription != entity.MetaDescription
    || skill.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(SkillDto skill)
  {
    List<FieldValuePayload> payloads = new(capacity: 1);

    if (skill.Attribute is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([skill.Attribute.Id]);
      payloads.Add(new FieldValuePayload(Skills.Attribute.ToString(), value));
    }

    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(SkillDto skill)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Skills.Slug.ToString(), skill.Slug)
    };
    if (!string.IsNullOrWhiteSpace(skill.Summary))
    {
      payloads.Add(new FieldValuePayload(Skills.Summary.ToString(), skill.Summary));
    }
    if (!string.IsNullOrWhiteSpace(skill.Description))
    {
      payloads.Add(new FieldValuePayload(Skills.HtmlContent.ToString(), skill.Description));
    }
    return payloads.AsReadOnly();
  }
}
