using Krakenar.Contracts.Search;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Customizations.Models;

public record SearchCustomizationsPayload : SearchPayload
{
  public CustomizationKind? Kind { get; set; }

  public new List<CustomizationSortOption> Sort { get; set; } = [];
}
