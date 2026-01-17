namespace SkillCraft.Tools.Shared.Models;

public record SpellAbilityDto
{
  public int Level { get; set; }
  public string? Name { get; set; }

  public SpellCastingDto Casting { get; set; } = new();
  public SpellDurationDto? Duration { get; set; }
  public int Range { get; set; }
  public SpellComponentsDto Components { get; set; } = new();

  public string? Description { get; set; }
}
