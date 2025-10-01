namespace SkillCraft.Cms.Core.Features.Models;

public record FeatureModel
{
  public string Name { get; set; }
  public string? Description { get; set; }

  public FeatureModel() : this(string.Empty)
  {
  }

  public FeatureModel(string name, string? description = null)
  {
    Name = name;
    Description = description;
  }
}
