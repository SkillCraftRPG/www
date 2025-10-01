using SkillCraft.Contracts;

namespace SkillCraft.Rules.Compiler.Models;

internal class Customization
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("kind")]
  public CustomizationKind Kind { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("summary")]
  public string Summary { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Customization customization && customization.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
