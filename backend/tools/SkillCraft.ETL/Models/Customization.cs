using SkillCraft.Core;

namespace SkillCraft.ETL.Models;

internal class Customization
{
  public Guid Id { get; set; }

  public CustomizationKind Kind { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Attribute attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
