using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds.Events;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Handlers;

internal class WorldEvents : IEventHandler<WorldCreated>, IEventHandler<WorldDeleted>, IEventHandler<WorldUpdated>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<WorldCreated>, WorldEvents>();
    services.AddTransient<IEventHandler<WorldDeleted>, WorldEvents>();
    services.AddTransient<IEventHandler<WorldUpdated>, WorldEvents>();
  }

  private readonly GameContext _context;

  public WorldEvents(GameContext context)
  {
    _context = context;
  }

  public async Task HandleAsync(WorldCreated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.AsNoTracking().SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is not null)
    {
      throw new InvalidOperationException($"World entity was not expected to be found, but was found at version {world.Version}.");
    }

    world = new WorldEntity(@event);
    _context.Worlds.Add(world);

    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task HandleAsync(WorldDeleted @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    long expectedVersion = @event.Version - 1;
    if (world is null || world.Version != expectedVersion)
    {
      throw new InvalidOperationException($"World entity was expected to be found at version {expectedVersion}, but was found at version {world?.Version ?? 0}.");
    }

    _context.Worlds.Remove(world);

    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task HandleAsync(WorldUpdated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    long expectedVersion = @event.Version - 1;
    if (world is null || world.Version != expectedVersion)
    {
      throw new InvalidOperationException($"World entity was expected to be found at version {expectedVersion}, but was found at version {world?.Version ?? 0}.");
    }

    world.Update(@event);

    await _context.SaveChangesAsync(cancellationToken);
  }
}
