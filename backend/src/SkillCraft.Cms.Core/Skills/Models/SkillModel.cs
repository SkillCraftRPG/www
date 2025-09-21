using Krakenar.Contracts;
using SkillCraft.Cms.Core.Attributes.Models;

namespace SkillCraft.Cms.Core.Skills.Models;

public class SkillModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public AttributeModel? Attribute { get; set; }
  public GameSkill Value { get; set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }
}
