using Logitar;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds;

public readonly struct WorldId
{
  private const char Separator = ':';

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public WorldId(StreamId streamId)
  {
    StreamId = streamId;
  }

  public WorldId(Guid id)
  {
    StreamId = new(string.Join(Separator, EntityKind.World, Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64()));
  }

  public WorldId(string value)
  {
    StreamId = new(value);
  }

  public static WorldId NewId() => new(Guid.NewGuid());

  public Guid ToGuid()
  {
    string[] parts = Value.Split(Separator);
    return new Guid(Convert.FromBase64String(parts[1].FromUriSafeBase64()));
  }

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
