using SkillCraft.Core.Storages.Events;

namespace SkillCraft.Infrastructure.Entities;

internal class StorageSummary : AggregateEntity
{
  public int StorageSummaryId { get; private set; }
  public Guid UserId { get; private set; }

  public long AllocatedBytes { get; private set; }
  public long UsedBytes { get; private set; }
  public long AvailableBytes
  {
    get => AllocatedBytes - UsedBytes;
    private set { }
  }

  public StorageSummary(StorageInitialized @event) : base(@event)
  {
    UserId = @event.UserId.ToGuid();

    AllocatedBytes = @event.AllocatedBytes;
  }

  private StorageSummary() : base()
  {
  }

  public void Store(long usedBytes, EntityStored @event)
  {
    Update(@event);

    UsedBytes = usedBytes;
  }
}
