namespace SkillCraft.Seeding.Game.Payloads;

public class CastePayload
{
  public Guid Id { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public Guid SkillId { get; set; }
  public string WealthRoll { get; set; } = string.Empty;

  public string? Feature { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is CastePayload caste && caste.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
