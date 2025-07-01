using Krakenar.Core.Contents;
using Krakenar.Core.Localization;
using Logitar.EventSourcing;
using SkillCraft.EntityFrameworkCore;
using SkillCraft.Harvesting.Models;
using SkillCraft.Infrastructure.Data;
using Attribute = SkillCraft.Harvesting.Models.Attribute;

namespace SkillCraft.Harvesting;

internal class EtlWorker : BackgroundService
{
  private static readonly IReadOnlyDictionary<Guid, EntityKind> _entityKinds = new Dictionary<Guid, EntityKind>
  {
    [Attributes.ContentTypeId] = EntityKind.Attribute,
    [Castes.ContentTypeId] = EntityKind.Caste,
    [Customizations.ContentTypeId] = EntityKind.Customization,
    [Educations.ContentTypeId] = EntityKind.Education,
    [Skills.ContentTypeId] = EntityKind.Skill,
    [Statistics.ContentTypeId] = EntityKind.Statistic,
    [Talents.ContentTypeId] = EntityKind.Talent
  }.AsReadOnly();
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
    List<Education> educations = [];
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
        continue;
      }

      Guid contentTypeId = content.ContentTypeId.EntityId;
      if (!_entityKinds.TryGetValue(contentTypeId, out EntityKind kind))
      {
        continue;
      }

      _logger.LogInformation("Extracting {Kind} from content {Content}...", kind, content);
      switch (kind)
      {
        case EntityKind.Attribute:
          Attribute attribute = Attribute.Extract(content, locale);
          attributes.Add(attribute);
          break;
        case EntityKind.Caste:
          Caste caste = Caste.Extract(content, locale);
          castes.Add(caste);
          break;
        case EntityKind.Customization:
          Customization customization = Customization.Extract(content, locale);
          customizations.Add(customization);
          break;
        case EntityKind.Education:
          Education education = Education.Extract(content, locale);
          educations.Add(education);
          break;
        case EntityKind.Skill:
          Skill skill = Skill.Extract(content, locale);
          skills.Add(skill);
          break;
        case EntityKind.Statistic:
          Statistic statistic = Statistic.Extract(content, locale);
          statistics.Add(statistic);
          break;
        case EntityKind.Talent:
          Talent talent = Talent.Extract(content, locale);
          talents.Add(talent);
          break;
        default:
          throw new NotSupportedException($"The entity kind '{kind}' is not supported.");
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
      "output/educations.json",
      JsonSerializer.Serialize(educations.OrderBy(x => x.Name), _serializerOptions),
      _encoding,
      cancellationToken);
    _logger.LogInformation("Serialized {Count} educations to file '{Path}'.", educations.Count, "output/educations.json");
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
}
