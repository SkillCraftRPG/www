using SkillCraft.Core;

namespace SkillCraft.Seeding.Game.Payloads;

public class AttributePayload
{
  public Guid Id { get; set; }
  public GameAttribute Value { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is AttributePayload attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
