using SkillCraft.Core;

namespace SkillCraft.Seeding.Game.Payloads;

public class CustomizationPayload
{
  public Guid Id { get; set; }
  public CustomizationKind Kind { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is CustomizationPayload customization && customization.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
