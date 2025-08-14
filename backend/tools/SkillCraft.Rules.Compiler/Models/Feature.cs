namespace SkillCraft.Rules.Compiler.Models;

internal record Feature
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;
}
