using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Storage;

public interface IStorageService
{
  Task EnsureAvailableAsync(World world, CancellationToken cancellationToken = default);
  Task UpdateAsync(World world, CancellationToken cancellationToken = default);
}

internal class StorageService : IStorageService
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IStorageService, StorageService>();
  }

  public async Task EnsureAvailableAsync(World world, CancellationToken cancellationToken)
  {
    // TODO(fpion): implement
  }

  public async Task UpdateAsync(World world, CancellationToken cancellationToken)
  {
    // TODO(fpion): implement
  }
}
