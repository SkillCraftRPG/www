using Krakenar.Contracts;

namespace SkillCraft.Core.Rules.Models;

public class SkillModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public GameSkill Value { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public AttributeModel? Attribute { get; set; }
}
