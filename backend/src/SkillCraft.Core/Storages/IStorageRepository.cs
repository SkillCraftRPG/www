namespace SkillCraft.Core.Storages;

public interface IStorageRepository
{
  Task<Storage?> LoadAsync(UserId userId, CancellationToken cancellationToken = default);
  Task<Storage?> LoadAsync(StorageId storageId, CancellationToken cancellationToken = default);

  Task SaveAsync(Storage storage, CancellationToken cancellationToken = default);
  Task SaveAsync(IEnumerable<Storage> storages, CancellationToken cancellationToken = default);
}
