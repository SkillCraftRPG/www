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
    StreamId = IdHelper.Construct(EntityKind.World, id);
  }

  public WorldId(string value)
  {
    StreamId = new(value);
  }

  public static WorldId NewId() => new(Guid.NewGuid());

  public Guid ToGuid() => IdHelper.Deconstruct(StreamId, EntityKind.World).Item1;

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
