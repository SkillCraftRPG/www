using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface ICustomizationQuerier
{
  Task<IReadOnlyCollection<CustomizationModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<CustomizationModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
