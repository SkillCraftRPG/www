using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds;

public readonly struct WorldId
{
  private const string EntityKind = "World";

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public WorldId(StreamId streamId)
  {
    IdHelper.Validate(streamId.Value, EntityKind);
    StreamId = streamId;
  }

  public WorldId(Guid id)
  {
    StreamId = new(IdHelper.Combine(EntityKind, id));
  }

  public WorldId(string value)
  {
    IdHelper.Validate(value, EntityKind);
    StreamId = new(value);
  }

  public static WorldId NewId() => new(Guid.NewGuid());
  public Guid ToGuid() => IdHelper.Parse(StreamId.Value, EntityKind).Item1;

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
