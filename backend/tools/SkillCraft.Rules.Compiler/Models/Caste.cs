namespace SkillCraft.Rules.Compiler.Models;

internal class Caste
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("skillId")]
  public Guid SkillId { get; set; }

  [JsonPropertyName("wealthRoll")]
  public string WealthRoll { get; set; } = string.Empty;

  [JsonPropertyName("summary")]
  public string Summary { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("feature")]
  public Feature Feature { get; set; } = new();

  [JsonPropertyName("notes")]
  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Caste caste && caste.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
