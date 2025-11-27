using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core;
using SkillCraft.Core.Storages.Events;

namespace SkillCraft.Infrastructure.Handlers;

internal class StorageEvents : IEventHandler<EntityStored>, IEventHandler<StorageInitialized>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<EntityStored>, StorageEvents>();
    services.AddTransient<IEventHandler<StorageInitialized>, StorageEvents>();
  }

  private readonly GameContext _context;

  public StorageEvents(GameContext context)
  {
    _context = context;
  }

  public async Task HandAsync(EntityStored @event, CancellationToken cancellationToken)
  {
    // TODO(fpion): implement
  }

  public async Task HandAsync(StorageInitialized @event, CancellationToken cancellationToken)
  {
    // TODO(fpion): implement
  }
}
