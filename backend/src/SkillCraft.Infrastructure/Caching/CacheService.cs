using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Actors;
using SkillCraft.Core.Caching;

namespace SkillCraft.Infrastructure.Caching;

internal class CacheService : ICacheService
{
  public static void Register(IServiceCollection services)
  {
    services.AddMemoryCache();
    services.AddSingleton(serviceProvider => CachingSettings.Initialize(serviceProvider.GetRequiredService<IConfiguration>()));
    services.AddTransient<ICacheService, CacheService>();
  }

  private readonly IMemoryCache _memoryCache;
  private readonly CachingSettings _settings;

  public CacheService(IMemoryCache memoryCache, CachingSettings settings)
  {
    _memoryCache = memoryCache;
    _settings = settings;
  }

  public Actor? GetActor(ActorId id)
  {
    string key = GetActorKey(id);
    return _memoryCache.TryGetValue(key, out Actor? actor) ? actor : null;
  }
  public void RemoveActor(ActorId id)
  {
    string key = GetActorKey(id);
    _memoryCache.Remove(key);
  }
  public void SetActor(Actor actor)
  {
    string key = GetActorKey(ActorHelper.GetActorId(actor));
    _memoryCache.Set(key, actor, _settings.ActorLifetime);
  }
  private static string GetActorKey(ActorId id) => $"Actor.Id={id}";
}
