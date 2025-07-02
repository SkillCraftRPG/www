using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedEducationsTask : SeedingTask
{
  public override string? Description => "Seeds the education contents into Krakenar.";
  public string Language { get; }

  public SeedEducationsTask(string language)
  {
    Language = language;
  }
}

internal class SeedEducationsTaskHandler : INotificationHandler<SeedEducationsTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedEducationsTaskHandler> _logger;

  public SeedEducationsTaskHandler(IContentService contentService, ILogger<SeedEducationsTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedEducationsTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/educations.json", Encoding.UTF8, cancellationToken);
    IEnumerable<EducationPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<EducationPayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Educations.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (EducationPayload education in payloads)
      {
        string skill = SeedingSerializer.Serialize<Guid[]>([education.SkillId]);

        Content content;
        if (existingIds.Contains(education.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = education.Slug,
            DisplayName = education.Name,
            Description = education.Notes
          };
          invariant.FieldValues.Add(new FieldValuePayload(Educations.Skill.ToString(), skill));
          invariant.FieldValues.Add(new FieldValuePayload(Educations.WealthMultiplier.ToString(), education.WealthMultiplier.ToString()));
          _ = await _contentService.SaveLocaleAsync(education.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = education.Slug,
            DisplayName = education.Name,
            Description = education.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Educations.Slug.ToString(), education.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Educations.Summary.ToString(), education.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Educations.Description.ToString(), education.Description ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Educations.Feature.ToString(), education.Feature ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(education.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={education.Id}' was not found.");

          _logger.LogInformation("The education '{Education}' was updated.", education.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = education.Id,
            ContentType = Educations.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = education.Slug,
            DisplayName = education.Name,
            Description = education.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Educations.Skill.ToString(), skill));
          payload.FieldValues.Add(new FieldValuePayload(Educations.WealthMultiplier.ToString(), education.WealthMultiplier.ToString()));
          payload.FieldValues.Add(new FieldValuePayload(Educations.Slug.ToString(), education.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Educations.Summary.ToString(), education.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Educations.Description.ToString(), education.Description ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Educations.Feature.ToString(), education.Feature ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The education '{Education}' was created.", education.Name);
        }

        _ = await _contentService.PublishAsync(education.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(education.Id, task.Language, cancellationToken);
        _logger.LogInformation("The education '{Education}' was published.", education.Name);
      }
    }
  }
}
