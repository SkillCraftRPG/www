using Krakenar.Contracts;

namespace SkillCraft.Cms.Core.Talents.Models;

public class Talent : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public GameSkill? Skill { get; set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public Talent? RequiredTalent { get; set; }
  public List<Talent> RequiringTalents { get; set; } = [];
}
