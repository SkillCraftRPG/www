using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedCastesTask : SeedingTask
{
  public override string? Description => "Seeds the caste contents into Krakenar.";
  public string Language { get; }

  public SeedCastesTask(string language)
  {
    Language = language;
  }
}

internal class SeedCastesTaskHandler : INotificationHandler<SeedCastesTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedCastesTaskHandler> _logger;

  public SeedCastesTaskHandler(IContentService contentService, ILogger<SeedCastesTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedCastesTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/castes.json", Encoding.UTF8, cancellationToken);
    IEnumerable<CastePayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<CastePayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Castes.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (CastePayload caste in payloads)
      {
        string skill = SeedingSerializer.Serialize<Guid[]>([caste.SkillId]);

        Content content;
        if (existingIds.Contains(caste.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = caste.Slug,
            DisplayName = caste.Name,
            Description = caste.Notes
          };
          invariant.FieldValues.Add(new FieldValuePayload(Castes.Skill.ToString(), skill));
          invariant.FieldValues.Add(new FieldValuePayload(Castes.WealthRoll.ToString(), caste.WealthRoll));
          _ = await _contentService.SaveLocaleAsync(caste.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = caste.Slug,
            DisplayName = caste.Name,
            Description = caste.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Castes.Slug.ToString(), caste.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Castes.Summary.ToString(), caste.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Castes.Description.ToString(), caste.Description ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Castes.Feature.ToString(), caste.Feature ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(caste.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={caste.Id}' was not found.");

          _logger.LogInformation("The caste '{Caste}' was updated.", caste.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = caste.Id,
            ContentType = Castes.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = caste.Slug,
            DisplayName = caste.Name,
            Description = caste.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Castes.Skill.ToString(), skill));
          payload.FieldValues.Add(new FieldValuePayload(Castes.WealthRoll.ToString(), caste.WealthRoll));
          payload.FieldValues.Add(new FieldValuePayload(Castes.Slug.ToString(), caste.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Castes.Summary.ToString(), caste.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Castes.Description.ToString(), caste.Description ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Castes.Feature.ToString(), caste.Feature ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The caste '{Caste}' was created.", caste.Name);
        }

        _ = await _contentService.PublishAsync(caste.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(caste.Id, task.Language, cancellationToken);
        _logger.LogInformation("The caste '{Caste}' was published.", caste.Name);
      }
    }
  }
}
