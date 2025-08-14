using CsvHelper.Configuration.Attributes;

namespace SkillCraft.Rules.Compiler.Models;

internal class CastePayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(2)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(3)]
  [Name("skill")]
  public string Skill { get; set; } = string.Empty;

  [Index(4)]
  [Name("wealth_roll")]
  public string WealthRoll { get; set; } = string.Empty;

  [Index(5)]
  [Name("summary")]
  public string Summary { get; set; } = string.Empty;

  [Index(6)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  [Index(7)]
  [Name("feature_name")]
  public string FeatureName { get; set; } = string.Empty;

  [Index(8)]
  [Name("feature_description")]
  public string FeatureDescription { get; set; } = string.Empty;

  [Index(9)]
  [Name("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is CastePayload caste && caste.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
