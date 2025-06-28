using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Core.Rules;

public interface IEducationQuerier
{
  Task<IReadOnlyCollection<EducationModel>> ListAsync(CancellationToken cancellationToken = default);

  Task<EducationModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);
}
