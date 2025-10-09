using Krakenar.Contracts;
using SkillCraft.Cms.Core.Features.Models;
using SkillCraft.Cms.Core.Skills.Models;

namespace SkillCraft.Cms.Core.Castes.Models;

public class CasteModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public string? WealthRoll { get; set; }
  public SkillModel? Skill { get; set; }
  public FeatureModel? Feature { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
