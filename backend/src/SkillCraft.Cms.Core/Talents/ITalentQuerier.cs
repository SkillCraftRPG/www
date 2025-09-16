using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Core.Talents;

public interface ITalentQuerier
{
  Task<Talent?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<Talent?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<Talent>> SearchAsync(SearchTalentsPayload payload, CancellationToken cancellationToken = default);
}
