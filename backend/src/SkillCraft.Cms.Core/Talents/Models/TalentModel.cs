using Krakenar.Contracts;
using SkillCraft.Cms.Core.Skills.Models;

namespace SkillCraft.Cms.Core.Talents.Models;

public class TalentModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public SkillModel? Skill { get; set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public TalentModel? RequiredTalent { get; set; }
  public List<TalentModel> RequiringTalents { get; set; } = [];
}
