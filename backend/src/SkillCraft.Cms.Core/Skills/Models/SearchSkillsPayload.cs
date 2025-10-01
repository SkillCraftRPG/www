using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Skills.Models;

public record SearchSkillsPayload : SearchPayload
{
  public new List<SkillSortOption> Sort { get; set; } = [];
}
