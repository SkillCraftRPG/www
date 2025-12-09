using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Entities;
using SkillCraft.Infrastructure.GameDb;

namespace SkillCraft.Infrastructure.Queriers;

internal class WorldQuerier : IWorldQuerier
{
  private readonly IActorService _actorService;
  private readonly IApplicationContext _applicationContext;
  private readonly DbSet<WorldEntity> _worlds;

  public WorldQuerier(IActorService actorService, IApplicationContext applicationContext, GameContext context)
  {
    _actorService = actorService;
    _applicationContext = applicationContext;
    _worlds = context.Worlds;
  }

  public async Task<int> CountAsync(CancellationToken cancellationToken)
  {
    Guid userId = _applicationContext.UserId.ToGuid();
    return await _worlds.AsNoTracking().Where(x => x.UserId == userId).CountAsync(cancellationToken);
  }

  public async Task<WorldId?> FindIdAsync(Slug slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);
    string? streamId = await _worlds.AsNoTracking()
      .Where(x => x.SlugNormalized == slugNormalized)
      .Select(x => x.StreamId)
      .SingleOrDefaultAsync(cancellationToken);
    return string.IsNullOrWhiteSpace(streamId) ? null : new WorldId(streamId);
  }

  public async Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken)
  {
    return await ReadAsync(world.Id, cancellationToken)
      ?? throw new InvalidOperationException($"The world entity 'StreamId={world.Id}' was not found.");
  }
  public async Task<WorldModel?> ReadAsync(WorldId id, CancellationToken cancellationToken)
  {
    Guid userId = _applicationContext.UserId.ToGuid();
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.StreamId == id.Value && x.UserId == userId)
      .SingleOrDefaultAsync(cancellationToken);
    return world is null ? null : await MapAsync(world, cancellationToken);
  }
  public async Task<WorldModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    Guid userId = _applicationContext.UserId.ToGuid();
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.Id == id && x.UserId == userId)
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
