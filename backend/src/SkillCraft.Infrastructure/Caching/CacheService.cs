using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Caching;

namespace SkillCraft.Infrastructure.Caching;

internal class CacheService : ICacheService
{
  public static void Register(IServiceCollection services)
  {
    services.AddMemoryCache();
    services.AddTransient<ICacheService, CacheService>();
  }

  private readonly IMemoryCache _memoryCache;

  public CacheService(IMemoryCache memoryCache)
  {
    _memoryCache = memoryCache;
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
    //string key = GetActorKey(actor.GetActorId()); // TODO(fpion): implement
    //_memoryCache.Set(key, actor); // TODO(fpion): lifetime
  }
  private static string GetActorKey(ActorId id) => $"Actor:Id:{id}";
}
