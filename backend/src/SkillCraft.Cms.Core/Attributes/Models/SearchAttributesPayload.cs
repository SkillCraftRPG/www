using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Attributes.Models;

public record SearchAttributesPayload : SearchPayload
{
  public new List<AttributeSortOption> Sort { get; set; } = [];
}
