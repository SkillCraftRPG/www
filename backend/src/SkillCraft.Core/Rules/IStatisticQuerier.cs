using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface IStatisticQuerier
{
  Task<IReadOnlyCollection<StatisticModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<StatisticModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
