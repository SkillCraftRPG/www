using Krakenar.Core;
using Krakenar.Core.Users;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Actors;

internal static class ActorExtensions
{
  public static ActorId GetActorId(this UserId userId) => new(userId.Value);

  public static UserId GetUserId(this IApplicationContext context)
  {
    if (!context.ActorId.HasValue)
    {
      throw new InvalidOperationException("An authenticated user is required.");
    }
    return new(context.ActorId.Value.Value);
  }
}
