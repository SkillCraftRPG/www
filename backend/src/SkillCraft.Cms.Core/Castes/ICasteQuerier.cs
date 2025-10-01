using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Castes.Models;

namespace SkillCraft.Cms.Core.Castes;

public interface ICasteQuerier
{
  Task<CasteModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<CasteModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<CasteModel>> SearchAsync(SearchCastesPayload payload, CancellationToken cancellationToken = default);
}
