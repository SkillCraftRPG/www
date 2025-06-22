using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface IAttributeQuerier
{
  Task<IReadOnlyCollection<AttributeModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<AttributeModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
