using SkillCraft.Core;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class Mount
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("price")]
  public decimal Price { get; set; }

  [JsonPropertyName("vigor")]
  public int Vigor { get; set; }

  [JsonPropertyName("size")]
  public SizeCategory Size { get; set; }

  [JsonPropertyName("load")]
  public int? Load { get; set; }

  [JsonPropertyName("speed")]
  public decimal Speed { get; set; }

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is Mount mount && mount.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
