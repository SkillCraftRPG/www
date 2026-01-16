namespace SkillCraft.Cms.Core.Spells.Models;

public record SpellCastingModel
{
  public string Time { get; set; } = string.Empty;
  public bool Ritual { get; set; }
}
