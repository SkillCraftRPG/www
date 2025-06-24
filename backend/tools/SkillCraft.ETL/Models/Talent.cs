namespace SkillCraft.ETL.Models;

internal class Talent
{
  public Guid Id { get; set; }

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public Guid? SkillId { get; set; }
  public Guid? RequiredTalentId { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Talent talent && talent.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
