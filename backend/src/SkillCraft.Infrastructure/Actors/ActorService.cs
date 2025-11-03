using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;

namespace SkillCraft.Infrastructure.Actors;

public interface IActorService
{
  Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> ids, CancellationToken cancellationToken = default);
}

internal class ActorService : IActorService
{
  public Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> ids, CancellationToken cancellationToken)
  {
    Dictionary<ActorId, Actor> actors = [];
    // TODO(fpion): implement
    return Task.FromResult((IReadOnlyDictionary<ActorId, Actor>)actors.AsReadOnly());
  }
}
