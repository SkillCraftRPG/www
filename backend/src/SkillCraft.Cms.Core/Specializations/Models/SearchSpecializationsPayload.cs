using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Specializations.Models;

public record SearchSpecializationsPayload : SearchPayload
{
  public new List<SpecializationSortOption> Sort { get; set; } = [];
}
