using CsvHelper.Configuration.Attributes;
using SkillCraft.Contracts;

namespace SkillCraft.Rules.Compiler.Models;

internal class AttributePayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(2)]
  [Name("value")]
  public GameAttribute Value { get; set; }

  [Index(3)]
  [Name("category")]
  public AttributeCategory? Category { get; set; }

  [Index(4)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(5)]
  [Name("summary")]
  public string Summary { get; set; } = string.Empty;

  [Index(6)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  [Index(7)]
  [Name("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is AttributePayload attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
