using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds;

public interface IWorldQuerier
{
  Task<int> CountAsync(CancellationToken cancellationToken = default);

  Task<WorldId?> FindIdAsync(Slug slug, CancellationToken cancellationToken = default);

  Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(WorldId id, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
}
