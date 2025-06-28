using Krakenar.Core.Contents;
using Krakenar.Core.Fields;
using Krakenar.Core.Localization;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Fields;
using SkillCraft.ETL.Constants;
using SkillCraft.ETL.Models;
using Attribute = SkillCraft.ETL.Models.Attribute;

namespace SkillCraft.ETL;

internal class EtlWorker : BackgroundService
{
  private static readonly Encoding _encoding = Encoding.UTF8;
  private static readonly Guid _realmId = Guid.Parse("cdc7f23d-6338-4c5d-81fe-dcc1bbfd8b05");

  private readonly IHostApplicationLifetime _hostApplicationLifetime;
  private readonly ILogger<EtlWorker> _logger;
  private readonly JsonSerializerOptions _serializerOptions = new();
  private readonly IServiceProvider _serviceProvider;

  public EtlWorker(IHostApplicationLifetime hostApplicationLifetime, ILogger<EtlWorker> logger, IServiceProvider serviceProvider)
  {
    _hostApplicationLifetime = hostApplicationLifetime;
    _logger = logger;
    _serviceProvider = serviceProvider;

    _serializerOptions.Converters.Add(new JsonStringEnumConverter());
    _serializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    _serializerOptions.WriteIndented = true;
  }

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    _logger.LogInformation("Worker executing at {Timestamp}.", DateTime.Now);

    using IServiceScope scope = _serviceProvider.CreateScope();
    IRepository repository = scope.ServiceProvider.GetRequiredService<IRepository>();

    IReadOnlyCollection<Language> languages = (await repository.LoadAsync<Language>(isDeleted: false, cancellationToken))
      .Where(l => l.RealmId.HasValue && l.RealmId.Value.ToGuid() == _realmId && l.IsDefault)
      .ToList()
      .AsReadOnly();
    if (languages.Count < 1)
    {
      _logger.LogWarning("The default language was not found for realm 'Id={RealmId}'.", _realmId);
      return;
    }
    else if (languages.Count > 1)
    {
      _logger.LogWarning("Multiple default languages ({Languages}) were found for realm 'Id={RealmId}'.", languages.Count, _realmId);
      return;
    }
    Language language = languages.Single();

    List<Attribute> attributes = [];
    List<Caste> castes = [];
    List<Customization> customizations = [];
    List<Skill> skills = [];
    List<Statistic> statistics = [];
    List<Talent> talents = [];

    IReadOnlyCollection<Content> contents = await repository.LoadAsync<Content>(isDeleted: false, cancellationToken);
    _logger.LogInformation("Retrieved {Contents} content(s) from the event store.", contents.Count);

    foreach (Content content in contents)
    {
      Guid? realmId = content.RealmId?.ToGuid();
      if (!realmId.HasValue || realmId.Value != _realmId)
      {
        continue;
      }

      ContentLocale? locale = content.TryGetLocale(language.Id);
      if (locale is null)
      {
        _logger.LogWarning("Default locale not found for content 'Id={ContentId}'.", content.Id);
        return;
      }

      Guid contentTypeId = content.ContentTypeId.EntityId;
      if (contentTypeId == ContentTypes.Attribute)
      {
        Attribute attribute = ParseAttribute(content, locale);
        attributes.Add(attribute);
      }
      else if (contentTypeId == ContentTypes.Caste)
      {
        Caste caste = ParseCaste(content, locale);
        castes.Add(caste);
      }
      else if (contentTypeId == ContentTypes.Customization)
      {
        Customization customization = ParseCustomization(content, locale);
        customizations.Add(customization);
      }
      else if (contentTypeId == ContentTypes.Skill)
      {
        Skill skill = ParseSkill(content, locale);
        skills.Add(skill);
      }
      else if (contentTypeId == ContentTypes.Statistic)
      {
        Statistic statistic = ParseStatistic(content, locale);
        statistics.Add(statistic);
      }
      else if (contentTypeId == ContentTypes.Talent)
      {
        Talent talent = ParseTalent(content, locale);
        talents.Add(talent);
      }
    }

    Directory.CreateDirectory("output");

    await File.WriteAllTextAsync(
      "output/attributes.json",
      JsonSerializer.Serialize(attributes.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} attributes to file '{Path}'.", attributes.Count, "output/attributes.json");
    await File.WriteAllTextAsync(
      "output/castes.json",
      JsonSerializer.Serialize(castes.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} castes to file '{Path}'.", castes.Count, "output/castes.json");
    await File.WriteAllTextAsync(
      "output/customizations.json",
      JsonSerializer.Serialize(customizations.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} customizations to file '{Path}'.", customizations.Count, "output/customizations.json");
    await File.WriteAllTextAsync(
      "output/skills.json",
      JsonSerializer.Serialize(skills.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} skills to file '{Path}'.", skills.Count, "output/skills.json");
    await File.WriteAllTextAsync(
      "output/statistics.json",
      JsonSerializer.Serialize(statistics.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} statistics to file '{Path}'.", statistics.Count, "output/statistics.json");
    await File.WriteAllTextAsync(
      "output/talents.json",
      JsonSerializer.Serialize(talents.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} talents to file '{Path}'.", talents.Count, "output/talents.json");

    _hostApplicationLifetime.StopApplication();
  }

  private static Attribute ParseAttribute(Content content, ContentLocale locale)
  {
    Attribute attribute = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameAttribute>(locale.UniqueName.Value),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Attributes.Summary)
      {
        attribute.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Attributes.Description)
      {
        attribute.Description = fieldValue.Value.Value;
      }
    }

    return attribute;
  }

  private static Caste ParseCaste(Content content, ContentLocale locale)
  {
    Caste caste = new()
    {
      Id = content.EntityId,
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in content.Invariant.FieldValues)
    {
      if (fieldValue.Key == Castes.Skill)
      {
        IReadOnlyCollection<Guid> values = JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(fieldValue.Value.Value) ?? [];
        if (values.Count == 1)
        {
          caste.SkillId = values.Single();
        }
      }
      else if (fieldValue.Key == Castes.WealthRoll)
      {
        caste.WealthRoll = fieldValue.Value.Value;
      }
    }

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Castes.Summary)
      {
        caste.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Castes.Description)
      {
        caste.Description = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Castes.Feature)
      {
        caste.Feature = fieldValue.Value.Value;
      }
    }

    return caste;
  }

  private static Customization ParseCustomization(Content content, ContentLocale locale)
  {
    Customization customization = new()
    {
      Id = content.EntityId,
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    if (content.Invariant.FieldValues.TryGetValue(Customizations.Kind, out FieldValue? value))
    {
      IReadOnlyCollection<string> values = JsonSerializer.Deserialize<IReadOnlyCollection<string>>(value.Value) ?? [];
      if (values.Count == 1)
      {
        customization.Kind = Enum.Parse<CustomizationKind>(values.Single());
      }
    }

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Customizations.Summary)
      {
        customization.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Customizations.Description)
      {
        customization.Description = fieldValue.Value.Value;
      }
    }

    return customization;
  }

  private static Skill ParseSkill(Content content, ContentLocale locale)
  {
    Skill skill = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameSkill>(locale.UniqueName.Value),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    if (content.Invariant.FieldValues.TryGetValue(Skills.Attribute, out FieldValue? value))
    {
      IReadOnlyCollection<Guid> contentIds = JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(value.Value) ?? [];
      if (contentIds.Count == 1)
      {
        skill.AttributeId = contentIds.Single();
      }
    }

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Skills.Summary)
      {
        skill.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Skills.Description)
      {
        skill.Description = fieldValue.Value.Value;
      }
    }

    return skill;
  }

  private static Statistic ParseStatistic(Content content, ContentLocale locale)
  {
    Statistic statistic = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameStatistic>(locale.UniqueName.Value),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    if (content.Invariant.FieldValues.TryGetValue(Statistics.Attribute, out FieldValue? value))
    {
      IReadOnlyCollection<Guid> attributeIds = JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(value.Value) ?? [];
      if (attributeIds.Count == 1)
      {
        statistic.AttributeId = attributeIds.Single();
      }
    }

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Statistics.Summary)
      {
        statistic.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Statistics.Description)
      {
        statistic.Description = fieldValue.Value.Value;
      }
    }

    return statistic;
  }

  private static Talent ParseTalent(Content content, ContentLocale locale)
  {
    Talent talent = new()
    {
      Id = content.EntityId,
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Notes = locale.Description?.Value?.CleanTrim()
    };

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in content.Invariant.FieldValues)
    {
      if (fieldValue.Key == Talents.AllowMultiplePurchases)
      {
        talent.AllowMultiplePurchases = bool.Parse(fieldValue.Value.Value);
      }
      else if (fieldValue.Key == Talents.RequiredTalent)
      {
        IReadOnlyCollection<Guid> requiredTalentIds = JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(fieldValue.Value.Value) ?? [];
        if (requiredTalentIds.Count == 1)
        {
          talent.RequiredTalentId = requiredTalentIds.Single();
        }
      }
      else if (fieldValue.Key == Talents.Skill)
      {
        IReadOnlyCollection<Guid> skillIds = JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(fieldValue.Value.Value) ?? [];
        if (skillIds.Count == 1)
        {
          talent.SkillId = skillIds.Single();
        }
      }
      else if (fieldValue.Key == Talents.Tier)
      {
        talent.Tier = int.Parse(fieldValue.Value.Value);
      }
    }

    foreach (KeyValuePair<Guid, FieldValue> fieldValue in locale.FieldValues)
    {
      if (fieldValue.Key == Talents.Summary)
      {
        talent.Summary = fieldValue.Value.Value;
      }
      else if (fieldValue.Key == Talents.Description)
      {
        talent.Description = fieldValue.Value.Value;
      }
    }

    return talent;
  }
}
