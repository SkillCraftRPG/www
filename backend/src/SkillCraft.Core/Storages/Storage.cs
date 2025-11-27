using Logitar.EventSourcing;
using SkillCraft.Core.Storages.Events;

namespace SkillCraft.Core.Storages;

public class Storage : AggregateRoot
{
  public new StorageId Id => new(base.Id);

  public UserId UserId => Id.ToUserId();

  private readonly Dictionary<string, long> _storedEntities = [];

  public long AllocatedBytes { get; private set; }
  public long UsedBytes => _storedEntities.Sum(x => x.Value);
  public long AvailableBytes => AllocatedBytes - UsedBytes;

  public Storage() : base()
  {
  }

  public Storage(UserId userId, long allocatedBytes) : base(new StorageId(userId).StreamId)
  {
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(allocatedBytes, nameof(allocatedBytes));
    Raise(new StorageInitialized(userId, allocatedBytes), userId.ActorId);
  }
  protected virtual void Handle(StorageInitialized @event)
  {
    AllocatedBytes = @event.AllocatedBytes;
  }

  public void EnsureAvailable(string key, long size)
  {
    _ = _storedEntities.TryGetValue(key, out long existingSize);
    size -= existingSize;
    if (size > AvailableBytes)
    {
      throw new NotImplementedException(); // TODO(fpion): implement
    }
  }

  public void Store(string key, long size)
  {
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size, nameof(size));
    if (!_storedEntities.TryGetValue(key, out long existingSize) || existingSize != size)
    {
      Raise(new EntityStored(key, size), UserId.ActorId);
    }
  }
  protected virtual void Handle(EntityStored @event)
  {
    _storedEntities[@event.Key] = @event.Size;
  }
}
