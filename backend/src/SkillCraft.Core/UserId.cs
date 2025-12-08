using Logitar.EventSourcing;

namespace SkillCraft.Core;

public readonly struct UserId
{
  private const string EntityKind = "User";

  public ActorId ActorId { get; }
  public string Value => ActorId.Value;

  public UserId(ActorId actorId)
  {
    IdHelper.Validate(actorId.Value, EntityKind);
    ActorId = actorId;
  }

  public static bool operator ==(UserId left, UserId right) => left.Equals(right);
  public static bool operator !=(UserId left, UserId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is UserId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
