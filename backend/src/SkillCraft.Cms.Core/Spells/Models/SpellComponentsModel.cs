namespace SkillCraft.Cms.Core.Spells.Models;

public record SpellComponentsModel
{
  public bool IsSomatic { get; set; }
  public bool IsVerbal { get; set; }
  public string? Focus { get; set; }
  public string? Material { get; set; }
}
