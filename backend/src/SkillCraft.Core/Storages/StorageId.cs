using Logitar.EventSourcing;

namespace SkillCraft.Core.Storages;

public readonly struct StorageId
{
  private const char Separator = ':';
  private const string Type = "Storage";

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public StorageId(StreamId streamId)
  {
    StreamId = streamId;
  }

  public StorageId(UserId userId)
  {
    StreamId = IdHelper.Construct(Type, userId.ToGuid());
  }

  public StorageId(string value)
  {
    StreamId = new(value);
  }

  public UserId ToUserId() => new(IdHelper.Deconstruct(StreamId, Type).Item1);

  public static bool operator ==(StorageId left, StorageId right) => left.Equals(right);
  public static bool operator !=(StorageId left, StorageId right) => !(left == right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is StorageId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
