using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Storages;

public interface IStorageService
{
  Task EnsureAvailableAsync(World world, CancellationToken cancellationToken = default);
  Task UpdateAsync(World world, CancellationToken cancellationToken = default);
}

internal class StorageService : IStorageService
{
  public static void Register(IServiceCollection services)
  {
    services.AddSingleton(serviceProvider => StorageSettings.Initialize(serviceProvider.GetRequiredService<IConfiguration>()));
    services.AddTransient<IStorageService, StorageService>();
  }

  private readonly StorageSettings _settings;
  private readonly IStorageRepository _storageRepository;

  public StorageService(StorageSettings settings, IStorageRepository storageRepository)
  {
    _settings = settings;
    _storageRepository = storageRepository;
  }

  public async Task EnsureAvailableAsync(World world, CancellationToken cancellationToken)
  {
    Storage storage = await LoadOrInitializeAsync(world.UserId, cancellationToken);
    storage.EnsureAvailable(world.Id.Value, world.Size);
  }

  public async Task UpdateAsync(World world, CancellationToken cancellationToken)
  {
    Storage storage = await LoadOrInitializeAsync(world.UserId, cancellationToken);

    storage.Store(world.Id.Value, world.Size);

    await _storageRepository.SaveAsync(storage, cancellationToken);
  }

  private async Task<Storage> LoadOrInitializeAsync(UserId userId, CancellationToken cancellationToken)
  {
    Storage? storage = await _storageRepository.LoadAsync(userId, cancellationToken);
    return storage ?? new(userId, _settings.AllocatedBytes);
  }
}
