using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface ICasteQuerier
{
  Task<IReadOnlyCollection<CasteModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<CasteModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
