using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Caching;

namespace SkillCraft.Infrastructure.Actors;

public interface IActorService
{
  Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken = default);
}

internal class ActorService : IActorService
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IActorService, ActorService>();
  }

  private readonly ICacheService _cacheService;

  public ActorService(ICacheService cacheService)
  {
    _cacheService = cacheService;
  }

  public async Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken)
  {
    int capacity = actorIds.Count();
    Dictionary<ActorId, Actor> actors = new(capacity);
    HashSet<ActorId> missing = new(capacity);

    foreach (ActorId actorId in actorIds)
    {
      Actor? actor = _cacheService.GetActor(actorId);
      if (actor is null)
      {
        missing.Add(actorId);
      }
      else
      {
        actors[actorId] = actor;
      }
    }

    if (missing.Count > 0)
    {
      // TODO(fpion): fetch from Krakenar
    }

    foreach (Actor actor in actors.Values)
    {
      _cacheService.SetActor(actor);
    }

    return actors;
  }
}
