using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Logitar;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedTalentsTask : SeedingTask
{
  public override string? Description => "Seeds the talent contents into Krakenar.";
  public string Language { get; }

  public SeedTalentsTask(string language)
  {
    Language = language;
  }
}

internal class SeedTalentsTaskHandler : INotificationHandler<SeedTalentsTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedTalentsTaskHandler> _logger;

  public SeedTalentsTaskHandler(IContentService contentService, ILogger<SeedTalentsTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedTalentsTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/talents.json", Encoding.UTF8, cancellationToken);
    IEnumerable<TalentPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<TalentPayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Talents.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      await SeedTalentsAsync(payloads, task.Language, existingIds, seededIds: new HashSet<Guid>(), cancellationToken);
    }
  }

  private async Task SeedTalentsAsync(
    IEnumerable<TalentPayload> talents,
    string language,
    IReadOnlySet<Guid> existingIds,
    IReadOnlySet<Guid> seededIds,
    CancellationToken cancellationToken)
  {
    int count = talents.Count();
    if (count < 1)
    {
      return;
    }

    List<TalentPayload> talentsToSeed = new(count);

    HashSet<Guid> talentIds = new(count);
    talentIds.AddRange(seededIds);

    foreach (TalentPayload talent in talents)
    {
      if (talent.RequiredTalentId.HasValue && !seededIds.Contains(talent.RequiredTalentId.Value))
      {
        talentsToSeed.Add(talent);
        continue;
      }

      string? skill = talent.SkillId.HasValue ? SeedingSerializer.Serialize<Guid[]>([talent.SkillId.Value]) : null;
      string? requiredTalent = talent.RequiredTalentId.HasValue ? SeedingSerializer.Serialize<Guid[]>([talent.RequiredTalentId.Value]) : null;

      if (existingIds.Contains(talent.Id))
      {
        SaveContentLocalePayload invariant = new()
        {
          UniqueName = talent.Slug,
          DisplayName = talent.Name,
          Description = talent.Notes
        };
        invariant.FieldValues.Add(new FieldValuePayload(Talents.Tier.ToString(), talent.Tier.ToString()));
        invariant.FieldValues.Add(new FieldValuePayload(Talents.AllowMultiplePurchases.ToString(), talent.AllowMultiplePurchases.ToString()));
        invariant.FieldValues.Add(new FieldValuePayload(Talents.Skill.ToString(), skill ?? string.Empty));
        invariant.FieldValues.Add(new FieldValuePayload(Talents.RequiredTalent.ToString(), requiredTalent ?? string.Empty));
        _ = await _contentService.SaveLocaleAsync(talent.Id, invariant, language: null, cancellationToken);

        SaveContentLocalePayload locale = new()
        {
          UniqueName = talent.Slug,
          DisplayName = talent.Name,
          Description = talent.Notes
        };
        locale.FieldValues.Add(new FieldValuePayload(Talents.Slug.ToString(), talent.Slug));
        locale.FieldValues.Add(new FieldValuePayload(Talents.Summary.ToString(), talent.Summary ?? string.Empty));
        locale.FieldValues.Add(new FieldValuePayload(Talents.Description.ToString(), talent.Description ?? string.Empty));
        _ = await _contentService.SaveLocaleAsync(talent.Id, locale, language, cancellationToken)
          ?? throw new InvalidOperationException($"The content 'Id={talent.Id}' was not found.");

        _logger.LogInformation("The talent '{Talent}' was updated.", talent.Name);
      }
      else
      {
        CreateContentPayload payload = new()
        {
          Id = talent.Id,
          ContentType = Talents.ContentTypeId.ToString(),
          Language = language,
          UniqueName = talent.Slug,
          DisplayName = talent.Name,
          Description = talent.Notes
        };
        payload.FieldValues.Add(new FieldValuePayload(Talents.Tier.ToString(), talent.Tier.ToString()));
        payload.FieldValues.Add(new FieldValuePayload(Talents.AllowMultiplePurchases.ToString(), talent.AllowMultiplePurchases.ToString()));
        payload.FieldValues.Add(new FieldValuePayload(Talents.Skill.ToString(), skill ?? string.Empty));
        payload.FieldValues.Add(new FieldValuePayload(Talents.RequiredTalent.ToString(), requiredTalent ?? string.Empty));
        payload.FieldValues.Add(new FieldValuePayload(Talents.Slug.ToString(), talent.Slug));
        payload.FieldValues.Add(new FieldValuePayload(Talents.Summary.ToString(), talent.Summary ?? string.Empty));
        payload.FieldValues.Add(new FieldValuePayload(Talents.Description.ToString(), talent.Description ?? string.Empty));
        _ = await _contentService.CreateAsync(payload, cancellationToken);
        _logger.LogInformation("The talent '{Talent}' was created.", talent.Name);
      }

      _ = await _contentService.PublishAsync(talent.Id, language: null, cancellationToken);
      _ = await _contentService.PublishAsync(talent.Id, language, cancellationToken);
      _logger.LogInformation("The talent '{Talent}' was published.", talent.Name);

      talentIds.Add(talent.Id);
    }

    await SeedTalentsAsync(talentsToSeed, language, existingIds, talentIds, cancellationToken);
  }
}
