using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.Core.Storages;

namespace SkillCraft.Infrastructure.Repositories;

internal class StorageRepository : Repository, IStorageRepository
{
  public StorageRepository(IEventStore eventStore) : base(eventStore)
  {
  }

  public async Task<Storage?> LoadAsync(UserId userId, CancellationToken cancellationToken)
  {
    return await LoadAsync(new StorageId(userId), cancellationToken);
  }
  public async Task<Storage?> LoadAsync(StorageId storageId, CancellationToken cancellationToken)
  {
    return await LoadAsync<Storage>(storageId.StreamId, cancellationToken);
  }

  public async Task SaveAsync(Storage storage, CancellationToken cancellationToken)
  {
    await base.SaveAsync(storage, cancellationToken);
  }
  public async Task SaveAsync(IEnumerable<Storage> storages, CancellationToken cancellationToken)
  {
    await base.SaveAsync(storages, cancellationToken);
  }
}
