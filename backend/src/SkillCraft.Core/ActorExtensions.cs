using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;

namespace SkillCraft.Core;

public static class ActorExtensions
{
  public static ActorId GetActorId(this Actor actor)
  {
    List<string> parts = new(capacity: 2);
    if (actor.RealmId.HasValue)
    {
      parts.Add(IdHelper.Combine("Realm", actor.RealmId.Value));
    }
    parts.Add(IdHelper.Combine(actor.Type.ToString(), actor.Id));
    return new ActorId(string.Join('|', parts));
  }
}
