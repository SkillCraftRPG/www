using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Core.Specializations.Models;

public record SpecializationOptions
{
  public List<TalentModel> Talents { get; set; } = [];
  public List<string> Other { get; set; } = [];
}
