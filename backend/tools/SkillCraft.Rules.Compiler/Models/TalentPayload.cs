using CsvHelper.Configuration.Attributes;

namespace SkillCraft.Rules.Compiler.Models;

internal class TalentPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("tier")]
  public int Tier { get; set; }

  [Index(2)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(3)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(4)]
  [Name("allow_multiple_purchases")]
  public bool AllowMultiplePurchases { get; set; }

  [Index(5)]
  [Name("skill")]
  public string? Skill { get; set; }

  [Index(6)]
  [Name("required_talent")]
  public string? RequiredTalent { get; set; }

  [Index(7)]
  [Name("summary")]
  public string Summary { get; set; } = string.Empty;

  [Index(8)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  [Index(9)]
  [Name("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is TalentPayload talent && talent.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
