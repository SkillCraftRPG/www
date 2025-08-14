using SkillCraft.Core;

namespace SkillCraft.Rules.Compiler.Models;

internal class Statistic
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("value")]
  public GameStatistic Value { get; set; }

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("attributeId")]
  public Guid AttributeId { get; set; }

  [JsonPropertyName("summary")]
  public string Summary { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Statistic statistic && statistic.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
