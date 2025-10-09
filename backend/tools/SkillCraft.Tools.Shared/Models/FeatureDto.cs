namespace SkillCraft.Tools.Shared.Models;

public class FeatureDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }

  public override bool Equals(object? obj) => obj is FeatureDto feature && feature.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
