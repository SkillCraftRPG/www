using SkillCraft.Cms.Core.Features.Models;
using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Core.Specializations.Models;

public record ReservedTalent
{
  public string Name { get; set; } = string.Empty;
  public List<string> Description { get; set; } = [];
  public List<TalentModel> DiscountedTalents { get; set; } = [];
  public List<FeatureModel> Features { get; set; } = [];
}
