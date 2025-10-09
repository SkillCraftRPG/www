namespace SkillCraft.Tools.Shared.Models;

public class TalentDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public RelationshipDto? Skill { get; set; }
  public RelationshipDto? RequiredTalent { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override bool Equals(object? obj) => obj is TalentDto talent && talent.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
