using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Localization;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Core.Talents.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedTalentsTask : SeedingTask
{
  public override string? Description => "Seeds the Talents contents.";
}

internal class SeedTalentsTaskHandler : ICommandHandler<SeedTalentsTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly ILanguageService _languageService;
  private readonly ILogger<SeedTalentsTaskHandler> _logger;

  public SeedTalentsTaskHandler(
    IContentService contentService,
    DefaultSettings defaults,
    ILanguageService languageService,
    ILogger<SeedTalentsTaskHandler> logger)
  {
    _contentService = contentService;
    _defaults = defaults;
    _languageService = languageService;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedTalentsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/talents.json", Encoding.UTF8, cancellationToken);
    TalentDto[] entities = SeedingSerializer.Deserialize<TalentDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Talents} talent(s).", entities.Length);

    if (entities.Length > 0)
    {
      IReadOnlyDictionary<Guid, TalentModel> talents = await LoadAsync(cancellationToken);
      _logger.LogInformation("Retrieved {Talents} talent(s) from database.", talents.Count);

      await SeedAsync(entities, talents.Keys, talents, cancellationToken);
    }

    return new TaskResult();
  }
  private async Task SeedAsync(
    IEnumerable<TalentDto> entities,
    IEnumerable<Guid> seededIds,
    IReadOnlyDictionary<Guid, TalentModel> talents,
    CancellationToken cancellationToken)
  {
    List<TalentDto> notSeeded = new(capacity: entities.Count());
    HashSet<Guid> seededIdSet = new(seededIds);

    foreach (TalentDto entity in entities)
    {
      _ = talents.TryGetValue(entity.Id, out TalentModel? talent);
      if (talent is null || HasChanges(talent, entity))
      {
        if (entity.RequiredTalent is not null && !seededIdSet.Contains(entity.RequiredTalent.Id))
        {
          notSeeded.Add(entity);
          continue;
        }

        Content content;
        if (talent is null)
        {
          CreateContentPayload payload = new()
          {
            Id = entity.Id,
            ContentType = Talents.ContentTypeId.ToString(),
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
            ?? throw new InvalidOperationException($"The talent content 'Id={entity.Id}' was not found.");

          SaveContentLocalePayload locale = new()
          {
            UniqueName = entity.Slug,
            DisplayName = entity.Name,
            Description = entity.MetaDescription
          };
          invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
          content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
            ?? throw new InvalidOperationException($"The talent content 'Id={entity.Id}' was not found.");
        }


        if (entity.IsPublished)
        {
          await _contentService.PublishAllAsync(content.Id, cancellationToken);
        }
        else
        {
          await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
        }

        seededIdSet.Add(content.Id);
        _logger.LogInformation("Talent '{Talent}' was seeded.", entity);
      }
      else
      {
        _logger.LogInformation("Talent '{Talent}' has no change.", talent);
      }
    }

    if (notSeeded.Count > 0)
    {
      await SeedAsync(notSeeded, seededIdSet, talents, cancellationToken);
    }
  }

  private async Task<IReadOnlyDictionary<Guid, TalentModel>> LoadAsync(CancellationToken cancellationToken)
  {
    SearchContentLocalesPayload payload = new()
    {
      ContentTypeId = Talents.ContentTypeId
    };
    SearchResults<ContentLocale> results = await _contentService.SearchLocalesAsync(payload, cancellationToken);
    Dictionary<Guid, ContentLocale> invariants = results.Items.ToDictionary(x => x.Content.Id, x => x);

    Language language = await _languageService.ReadAsync(id: null, locale: null, isDefault: true, cancellationToken)
      ?? throw new InvalidOperationException("The default language was not found.");
    payload.LanguageId = language.Id;
    results = await _contentService.SearchLocalesAsync(payload, cancellationToken);
    Dictionary<Guid, ContentLocale> locales = results.Items.ToDictionary(x => x.Content.Id, x => x);

    Dictionary<Guid, TalentModel> talents = new(capacity: invariants.Count);
    foreach (KeyValuePair<Guid, ContentLocale> content in invariants)
    {
      if (locales.TryGetValue(content.Key, out ContentLocale? locale))
      {
        ContentLocale invariant = content.Value;
        Dictionary<Guid, string> fields = invariant.FieldValues.Concat(locale.FieldValues).ToDictionary(x => x.Id, x => x.Value);

        TalentModel talent = new()
        {
          Id = content.Key,
          Name = locale.DisplayName ?? locale.UniqueName,
          MetaDescription = locale.Description
        };

        if (fields.TryGetValue(Talents.Tier, out string? value))
        {
          talent.Tier = int.Parse(value);
        }
        if (fields.TryGetValue(Talents.AllowMultiplePurchases, out value))
        {
          talent.AllowMultiplePurchases = bool.Parse(value);
        }
        if (fields.TryGetValue(Talents.Skill, out value))
        {
          IReadOnlyCollection<Guid> ids = SeedingSerializer.Deserialize<IReadOnlyCollection<Guid>>(value) ?? [];
          talent.Skill = new SkillModel
          {
            Id = ids.Single()
          };
        }
        if (fields.TryGetValue(Talents.RequiredTalent, out value))
        {
          IReadOnlyCollection<Guid> ids = SeedingSerializer.Deserialize<IReadOnlyCollection<Guid>>(value) ?? [];
          talent.RequiredTalent = new TalentModel
          {
            Id = ids.Single()
          };
        }

        if (fields.TryGetValue(Talents.Slug, out value))
        {
          talent.Slug = value;
        }
        if (fields.TryGetValue(Talents.Summary, out value))
        {
          talent.Summary = value;
        }
        if (fields.TryGetValue(Talents.HtmlContent, out value))
        {
          talent.Description = value;
        }

        talents[talent.Id] = talent;
      }
    }
    return talents.AsReadOnly();
  }

  private static bool HasChanges(TalentModel talent, TalentDto entity) => talent.Slug != entity.Slug
    || talent.Name != entity.Name
    || talent.Tier != entity.Tier
    || talent.AllowMultiplePurchases != entity.AllowMultiplePurchases
    || talent.Skill?.Id != entity.Skill?.Id
    || talent.RequiredTalent?.Id != entity.RequiredTalent?.Id
    || talent.Summary != entity.Summary
    || talent.MetaDescription != entity.MetaDescription
    || talent.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(TalentDto talent)
  {
    List<FieldValuePayload> payloads = new(capacity: 4)
    {
      new FieldValuePayload(Talents.Tier.ToString(), talent.Tier.ToString()),
      new FieldValuePayload(Talents.AllowMultiplePurchases.ToString(), talent.AllowMultiplePurchases.ToString())
    };
    if (talent.Skill is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([talent.Skill.Id]);
      payloads.Add(new FieldValuePayload(Talents.Skill.ToString(), value));
    }
    if (talent.RequiredTalent is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([talent.RequiredTalent.Id]);
      payloads.Add(new FieldValuePayload(Talents.RequiredTalent.ToString(), value));
    }
    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(TalentDto talent)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Talents.Slug.ToString(), talent.Slug)
    };
    if (!string.IsNullOrWhiteSpace(talent.Summary))
    {
      payloads.Add(new FieldValuePayload(Talents.Summary.ToString(), talent.Summary));
    }
    if (!string.IsNullOrWhiteSpace(talent.Description))
    {
      payloads.Add(new FieldValuePayload(Talents.HtmlContent.ToString(), talent.Description));
    }
    return payloads.AsReadOnly();
  }
}
