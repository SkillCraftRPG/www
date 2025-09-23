using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Core.Talents;

public interface ITalentQuerier
{
  Task<TalentModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<TalentModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<TalentModel>> SearchAsync(SearchTalentsPayload payload, CancellationToken cancellationToken = default);
}
