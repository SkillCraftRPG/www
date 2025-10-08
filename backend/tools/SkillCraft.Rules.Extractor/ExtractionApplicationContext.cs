using Krakenar.Contracts.Configurations;
using Krakenar.Contracts.Logging;
using Krakenar.Contracts.Settings;
using Krakenar.Core;
using Krakenar.Core.Caching;
using Krakenar.Core.Realms;
using Krakenar.Core.Tokens;
using Logitar.EventSourcing;
using Realm = Krakenar.Contracts.Realms.Realm;

namespace SkillCraft.Rules.Extractor;

internal record ExtractionApplicationContext : IApplicationContext
{
  private readonly ICacheService _cacheService;

  public ExtractionApplicationContext(ICacheService cacheService)
  {
    _cacheService = cacheService;
  }

  protected virtual Configuration Configuration => _cacheService.Configuration ?? throw new InvalidOperationException("The configuration was not found in the cache.");

  public ActorId? ActorId { get; }

  public string BaseUrl { get; } = "extraction";

  public Realm? Realm { get; }
  public RealmId? RealmId => Realm is null ? null : new RealmId(Realm.Id);

  public Secret Secret => new(Realm?.Secret ?? Configuration.Secret ?? string.Empty);
  public IUniqueNameSettings UniqueNameSettings => Realm?.UniqueNameSettings ?? Configuration.UniqueNameSettings;
  public IPasswordSettings PasswordSettings => Realm?.PasswordSettings ?? Configuration.PasswordSettings;
  public bool RequireUniqueEmail => Realm?.RequireUniqueEmail ?? false;
  public bool RequireConfirmedAccount => Realm?.RequireConfirmedAccount ?? false;

  public ILoggingSettings LoggingSettings => Configuration.LoggingSettings;
}
