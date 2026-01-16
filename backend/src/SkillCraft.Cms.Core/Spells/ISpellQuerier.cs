using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Spells.Models;

namespace SkillCraft.Cms.Core.Spells;

public interface ISpellQuerier
{
  Task<SpellModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<SpellModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<SpellModel>> SearchAsync(SearchSpellsPayload payload, CancellationToken cancellationToken = default);
}
