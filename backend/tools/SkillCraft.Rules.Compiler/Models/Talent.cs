namespace SkillCraft.Rules.Compiler.Models;

internal class Talent
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("tier")]
  public int Tier { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("allowMultiplePurchases")]
  public bool AllowMultiplePurchases { get; set; }

  [JsonPropertyName("skillId")]
  public Guid? SkillId { get; set; }

  [JsonPropertyName("requiredTalentId")]
  public Guid? RequiredTalentId { get; set; }

  [JsonPropertyName("summary")]
  public string Summary { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Talent talent && talent.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
