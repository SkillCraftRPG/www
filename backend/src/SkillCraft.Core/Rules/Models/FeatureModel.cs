namespace SkillCraft.Core.Rules.Models;

public record FeatureModel
{
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
}
