using Logitar;
using Logitar.EventSourcing;

namespace SkillCraft.Core;

public readonly struct UserId
{
  private const char Separator = ':';

  public ActorId ActorId { get; }
  public string Value => ActorId.Value;

  public UserId(ActorId actorId)
  {
    if (actorId.Value.Split(Separator).First() != "User")
    {
      throw new ArgumentException($"{actorId} is not a valid user ID.", nameof(actorId));
    }
    ActorId = actorId;
  }

  public Guid ToGuid()
  {
    string[] parts = Value.Split(Separator);
    return new Guid(Convert.FromBase64String(parts[1].FromUriSafeBase64()));
  }

  public static bool operator ==(UserId left, UserId right) => left.Equals(right);
  public static bool operator !=(UserId left, UserId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is UserId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value.ToString();
}
