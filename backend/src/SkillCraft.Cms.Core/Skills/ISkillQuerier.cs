using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Skills.Models;

namespace SkillCraft.Cms.Core.Skills;

public interface ISkillQuerier
{
  Task<SkillModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<SkillModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<SkillModel>> SearchAsync(SearchSkillsPayload payload, CancellationToken cancellationToken = default);
}
