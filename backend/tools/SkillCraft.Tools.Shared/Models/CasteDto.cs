namespace SkillCraft.Tools.Shared.Models;

public class CasteDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public string? WealthRoll { get; set; }
  public RelationshipDto? Skill { get; set; }
  public FeatureDto? Feature { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override bool Equals(object? obj) => obj is CasteDto caste && caste.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
