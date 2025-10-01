using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Educations.Models;

namespace SkillCraft.Cms.Core.Educations;

public interface IEducationQuerier
{
  Task<EducationModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<EducationModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<EducationModel>> SearchAsync(SearchEducationsPayload payload, CancellationToken cancellationToken = default);
}
