using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Lineages.Models;

namespace SkillCraft.Cms.Core.Lineages;

public interface ILineageQuerier
{
  Task<LineageModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<LineageModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<LineageModel>> SearchAsync(SearchLineagesPayload payload, CancellationToken cancellationToken = default);
}
