using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedSkillsTask : SeedingTask
{
  public override string? Description => "Seeds the skill contents into Krakenar.";
  public string Language { get; }

  public SeedSkillsTask(string language)
  {
    Language = language;
  }
}

internal class SeedSkillsTaskHandler : INotificationHandler<SeedSkillsTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedSkillsTaskHandler> _logger;

  public SeedSkillsTaskHandler(IContentService contentService, ILogger<SeedSkillsTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedSkillsTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/skills.json", Encoding.UTF8, cancellationToken);
    IEnumerable<SkillPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<SkillPayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Skills.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (SkillPayload skill in payloads)
      {
        string? attribute = skill.AttributeId.HasValue ? SeedingSerializer.Serialize<Guid[]>([skill.AttributeId.Value]) : null;

        Content content;
        if (existingIds.Contains(skill.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = skill.Value.ToString(),
            DisplayName = skill.Name,
            Description = skill.Notes
          };
          invariant.FieldValues.Add(new FieldValuePayload(Skills.Attribute.ToString(), attribute ?? string.Empty));
          _ = await _contentService.SaveLocaleAsync(skill.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = skill.Value.ToString(),
            DisplayName = skill.Name,
            Description = skill.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Skills.Slug.ToString(), skill.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Skills.Summary.ToString(), skill.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Skills.Description.ToString(), skill.Description ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(skill.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={skill.Id}' was not found.");

          _logger.LogInformation("The skill '{Skill}' was updated.", skill.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = skill.Id,
            ContentType = Skills.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = skill.Value.ToString(),
            DisplayName = skill.Name,
            Description = skill.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Skills.Attribute.ToString(), attribute ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Skills.Slug.ToString(), skill.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Skills.Summary.ToString(), skill.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Skills.Description.ToString(), skill.Description ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The skill '{Skill}' was created.", skill.Name);
        }

        _ = await _contentService.PublishAsync(skill.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(skill.Id, task.Language, cancellationToken);
        _logger.LogInformation("The skill '{Skill}' was published.", skill.Name);
      }
    }
  }
}
