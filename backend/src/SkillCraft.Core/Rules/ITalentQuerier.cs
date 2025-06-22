using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface ITalentQuerier
{
  Task<IReadOnlyCollection<TalentModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<TalentModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
