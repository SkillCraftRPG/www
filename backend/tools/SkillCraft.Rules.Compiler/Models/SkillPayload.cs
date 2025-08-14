using CsvHelper.Configuration.Attributes;

namespace SkillCraft.Rules.Compiler.Models;

internal class SkillPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(2)]
  [Name("value")]
  public GameSkill Value { get; set; }

  [Index(3)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(4)]
  [Name("attribute")]
  public string? Attribute { get; set; }

  [Index(5)]
  [Name("summary")]
  public string Summary { get; set; } = string.Empty;

  [Index(6)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  [Index(7)]
  [Name("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is SkillPayload skill && skill.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
