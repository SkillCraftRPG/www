using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Specializations.Models;

namespace SkillCraft.Cms.Core.Specializations;

public interface ISpecializationQuerier
{
  Task<SpecializationModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<SpecializationModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<SpecializationModel>> SearchAsync(SearchSpecializationsPayload payload, CancellationToken cancellationToken = default);
}
