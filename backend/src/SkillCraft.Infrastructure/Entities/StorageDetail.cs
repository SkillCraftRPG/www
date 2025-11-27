using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.Core.Storages.Events;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Infrastructure.Entities;

internal class StorageDetail
{
  public int StorageDetailId { get; private set; }
  public string Key { get; private set; } = string.Empty;

  public WorldEntity? World { get; private set; }
  public int WorldId { get; private set; }
  public Guid WorldUid { get; private set; }

  public string EntityKind { get; private set; } = string.Empty;
  public Guid EntityId { get; private set; }

  public long Size { get; private set; }

  public long Version { get; private set; }
  public string? StoredBy { get; private set; }
  public DateTime StoredOn { get; private set; }

  public StorageDetail(WorldEntity world, EntityStored @event)
  {
    Key = @event.Key;

    World = world;
    WorldId = world.WorldId;
    WorldUid = world.Id;

    Tuple<string, Guid, WorldId?> entity = IdHelper.Deconstruct(new StreamId(@event.Key));
    EntityKind = entity.Item1;
    EntityId = entity.Item2;

    Update(@event);
  }

  private StorageDetail()
  {
  }

  public void Update(EntityStored @event)
  {
    Size = @event.Size;

    Version = @event.Version;
    StoredBy = @event.ActorId?.Value;
    StoredOn = @event.OccurredOn.AsUniversalTime();
  }
}
