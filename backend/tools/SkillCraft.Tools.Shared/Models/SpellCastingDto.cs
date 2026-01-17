namespace SkillCraft.Tools.Shared.Models;

public record SpellCastingDto
{
  public string Time { get; set; } = string.Empty;
  public bool Ritual { get; set; }
}
