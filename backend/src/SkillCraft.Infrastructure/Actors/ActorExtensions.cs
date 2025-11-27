using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;

namespace SkillCraft.Infrastructure.Actors;

internal static class ActorExtensions
{
  public static ActorId GetActorId(this Actor actor) => new(string.Join(':', actor.Type, Convert.ToBase64String(actor.Id.ToByteArray()).ToUriSafeBase64()));
}
