using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Contracts.Users;
using Logitar.EventSourcing;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Actors;
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
  private readonly IUserService _userService;

  public ActorService(ICacheService cacheService, IUserService userService)
  {
    _cacheService = cacheService;
    _userService = userService;
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
      SearchUsersPayload payload = new();
      foreach (ActorId actorId in missing)
      {
        Actor actor = ActorHelper.ToActor(actorId);
        if (actor.RealmId.HasValue && actor.Type == ActorType.User)
        {
          payload.Ids.Add(actor.Id);
        }
      }

      SearchResults<User> users = await _userService.SearchAsync(payload, cancellationToken);
      foreach (User user in users.Items)
      {
        Actor actor = new(user);
        ActorId actorId = ActorHelper.GetActorId(actor);
        actors[actorId] = actor;
      }
    }

    foreach (Actor actor in actors.Values)
    {
      _cacheService.SetActor(actor);
    }

    return actors;
  }
}
