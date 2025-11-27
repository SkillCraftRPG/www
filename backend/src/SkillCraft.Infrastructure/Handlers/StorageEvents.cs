using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core;
using SkillCraft.Core.Storages.Events;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Entities;

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

  public async Task HandleAsync(EntityStored @event, CancellationToken cancellationToken)
  {
    // Storage Detail
    StorageDetail? detail = await _context.StorageDetail.SingleOrDefaultAsync(x => x.Key == @event.Key, cancellationToken);
    if (detail is null)
    {
      WorldEntity world;
      Tuple<string, Guid, WorldId?> entity = IdHelper.Deconstruct(new StreamId(@event.Key));
      if (entity.Item3.HasValue)
      {
        world = await _context.Worlds.SingleOrDefaultAsync(x => x.StreamId == entity.Item3.Value.Value, cancellationToken)
          ?? throw new InvalidOperationException($"The world entity 'StreamId={entity.Item3}' was not found.");
      }
      else
      {
        world = await _context.Worlds.SingleOrDefaultAsync(x => x.Id == entity.Item2, cancellationToken)
          ?? throw new InvalidOperationException($"The world entity 'Id={entity.Item2}' was not found.");
      }

      detail = new(world, @event);
      _context.StorageDetail.Add(detail);
    }
    else
    {
      detail.Update(@event);
    }
    await _context.SaveChangesAsync(cancellationToken);

    // Storage Summary
    StorageSummary? storage = await _context.StorageSummary.SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    long expectedVersion = @event.Version - 1;
    if (storage is null || storage.Version != expectedVersion)
    {
      throw new InvalidOperationException($"Storage entity was expected to be found at version {expectedVersion}, but was found at version {storage?.Version ?? 0}.");
    }

    long usedBytes = await _context.StorageDetail.AsNoTracking()
      .Include(x => x.World)
      .Where(x => x.World!.UserId == storage.UserId)
      .SumAsync(x => x.Size, cancellationToken);
    storage.Store(usedBytes, @event);

    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task HandleAsync(StorageInitialized @event, CancellationToken cancellationToken)
  {
    StorageSummary? storage = await _context.StorageSummary.AsNoTracking().SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (storage is not null)
    {
      throw new InvalidOperationException($"Storage entity was not expected to be found, but was found at version {storage.Version}.");
    }

    storage = new(@event);
    _context.StorageSummary.Add(storage);

    await _context.SaveChangesAsync(cancellationToken);
  }
}
