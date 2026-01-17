namespace SkillCraft.Tools.Shared.Models;

public record SpellComponentsDto
{
  public string? Focus { get; set; }
  public string? Material { get; set; }
  public bool Somatic { get; set; }
  public bool Verbal { get; set; }
}
