using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Core.Specializations.Models;

public record SpecializationRequirements
{
  public TalentModel? Talent { get; set; }
  public List<string> Other { get; set; } = [];
}
