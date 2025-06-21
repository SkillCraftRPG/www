using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface ISkillQuerier
{
  Task<IReadOnlyCollection<SkillModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<SkillModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
