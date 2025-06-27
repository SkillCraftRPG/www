using Krakenar.Contracts;

namespace SkillCraft.Core.Rules.Models;

public class CasteModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public SkillModel? Skill { get; set; }
  public string? WealthRoll { get; set; }
}
