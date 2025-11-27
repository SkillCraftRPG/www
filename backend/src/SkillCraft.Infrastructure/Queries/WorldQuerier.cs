using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Queries;

internal class WorldQuerier : IWorldQuerier
{
  private readonly IActorService _actorService;
  private readonly IContext _context;
  private readonly DbSet<WorldEntity> _worlds;

  public WorldQuerier(IActorService actorService, IContext context, GameContext game)
  {
    _actorService = actorService;
    _context = context;
    _worlds = game.Worlds;
  }

  public async Task<int> CountAsync(CancellationToken cancellationToken)
  {
    return await _worlds.Where(x => x.UserId == _context.UserId.ToGuid()).CountAsync(cancellationToken);
  }

  public async Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken)
  {
    return await ReadAsync(world.Id, cancellationToken) ?? throw new InvalidOperationException($"The world entity 'StreamId={world.Id}' was not found.");
  }
  public async Task<WorldModel?> ReadAsync(WorldId id, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.StreamId == id.Value && x.UserId == _context.UserId.ToGuid())
      .SingleOrDefaultAsync(cancellationToken);
    return world is null ? null : await MapAsync(world, cancellationToken);
  }
  public async Task<WorldModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.Id == id && x.UserId == _context.UserId.ToGuid())
      .SingleOrDefaultAsync(cancellationToken);
    return world is null ? null : await MapAsync(world, cancellationToken);
  }

  private async Task<WorldModel> MapAsync(WorldEntity world, CancellationToken cancellationToken)
  {
    return (await MapAsync([world], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<WorldModel>> MapAsync(IEnumerable<WorldEntity> worlds, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = worlds.SelectMany(world => world.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    GameMapper mapper = new(actors);

    return worlds.Select(mapper.ToWorld).ToList().AsReadOnly();
  }
}
