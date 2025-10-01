using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Customizations.Models;

namespace SkillCraft.Cms.Core.Customizations;

public interface ICustomizationQuerier
{
  Task<CustomizationModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<CustomizationModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<CustomizationModel>> SearchAsync(SearchCustomizationsPayload payload, CancellationToken cancellationToken = default);
}
