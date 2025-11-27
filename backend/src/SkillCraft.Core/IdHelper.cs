using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public static class IdHelper
{
  private const char Separator = '|';
  private const char EntitySeparator = ':';

  public static StreamId Construct(string entityType, Guid entityId, WorldId? worldId = null)
  {
    string entity = string.Join(EntitySeparator, entityType, Convert.ToBase64String(entityId.ToByteArray()).ToUriSafeBase64());
    return new StreamId(worldId.HasValue ? string.Join(Separator, worldId.Value, entity) : entity);
  }

  public static Tuple<string, Guid, WorldId?> Deconstruct(StreamId streamId)
  {
    string[] values = streamId.Value.Split(Separator);
    if (values.Length < 1 || values.Length > 2)
    {
      throw new ArgumentException($"The value '{streamId}' is not a valid entity identifier.", nameof(streamId));
    }

    string[] entity = values.Last().Split(EntitySeparator);
    if (entity.Length != 2)
    {
      throw new ArgumentException($"The value '{values.Last()}' is not a valid entity.", nameof(streamId));
    }

    Guid entityId = new(Convert.FromBase64String(entity.Last().FromUriSafeBase64()));
    WorldId? worldId = values.Length == 2 ? new(values.First()) : null;
    return Tuple.Create(entity.First(), entityId, worldId);
  }
  public static Tuple<Guid, WorldId?> Deconstruct(StreamId streamId, string expectedType)
  {
    string[] values = streamId.Value.Split(Separator);
    if (values.Length < 1 || values.Length > 2)
    {
      throw new ArgumentException($"The value '{streamId}' is not a valid entity identifier.", nameof(streamId));
    }

    string[] entity = values.Last().Split(EntitySeparator);
    if (entity.Length != 2)
    {
      throw new ArgumentException($"The value '{values.Last()}' is not a valid entity.", nameof(streamId));
    }

    if (entity.First() != expectedType)
    {
      throw new ArgumentException($"The entity type '{entity.First()}' was not expected ({expectedType}).", nameof(streamId));
    }
    Guid entityId = new(Convert.FromBase64String(entity.Last().FromUriSafeBase64()));

    WorldId? worldId = values.Length == 2 ? new(values.First()) : null;
    return Tuple.Create(entityId, worldId);
  }
}
