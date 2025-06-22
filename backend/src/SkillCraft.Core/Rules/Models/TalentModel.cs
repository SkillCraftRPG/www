using Krakenar.Contracts;

namespace SkillCraft.Core.Rules.Models;

public class TalentModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public int Tier { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public bool AllowMultiplePurchases { get; set; }
  public SkillModel? Skill { get; set; }
  public TalentModel? RequiredTalent { get; set; }
  public List<TalentModel> RequiringTalents { get; set; } = [];
}
