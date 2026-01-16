namespace SkillCraft.Cms.Core.Spells.Models;

public record SpellComponentsModel
{
  public string? Focus { get; set; }
  public string? Material { get; set; }
  public bool Somatic { get; set; }
  public bool Verbal { get; set; }
}
