using Krakenar.Contracts;

namespace SkillCraft.Cms.Core.Spells.Models;

public class SpellModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public List<SpellAbilityModel> Abilities { get; set; } = [];
}
