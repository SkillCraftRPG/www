using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Educations.Models;

public record SearchEducationsPayload : SearchPayload
{
  public new List<EducationSortOption> Sort { get; set; } = [];
}
