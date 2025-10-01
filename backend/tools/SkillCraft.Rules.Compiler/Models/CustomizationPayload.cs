using CsvHelper.Configuration.Attributes;
using SkillCraft.Contracts;

namespace SkillCraft.Rules.Compiler.Models;

internal class CustomizationPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("kind")]
  public CustomizationKind Kind { get; set; }

  [Index(2)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(3)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(4)]
  [Name("summary")]
  public string Summary { get; set; } = string.Empty;

  [Index(5)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  [Index(6)]
  [Name("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is CustomizationPayload customization && customization.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
