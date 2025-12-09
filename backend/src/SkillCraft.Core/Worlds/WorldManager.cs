using SkillCraft.Core.Worlds.Events;

namespace SkillCraft.Core.Worlds;

public interface IWorldManager
{
  Task SaveAsync(World world, CancellationToken cancellationToken = default);
}

internal class WorldManager : IWorldManager
{
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public WorldManager(IWorldQuerier worldQuerier, IWorldRepository worldRepository)
  {
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task SaveAsync(World world, CancellationToken cancellationToken)
  {
    if (world.Changes.Any(change => change is WorldCreated))
    {
      WorldId? worldId = await _worldQuerier.FindIdAsync(world.Slug, cancellationToken);
      if (worldId.HasValue && !worldId.Value.Equals(world.Id))
      {
        throw new SlugAlreadyUsedException(world, worldId.Value);
      }
    }

    // TASK: [SKILLCRAFT-12](https://logitar.atlassian.net/browse/SKILLCRAFT-12)

    await _worldRepository.SaveAsync(world, cancellationToken);

    // TASK: [SKILLCRAFT-12](https://logitar.atlassian.net/browse/SKILLCRAFT-12)
  }
}
