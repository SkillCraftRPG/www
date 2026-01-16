namespace SkillCraft.Cms.Core.Spells.Models;

public class SpellAbilityModel
{
  public int Level { get; set; }
  public string? Name { get; set; }

  public SpellCastingModel Casting { get; set; } = new();
  public SpellDurationModel? Duration { get; set; }
  public int Range { get; set; }
  public SpellComponentsModel Components { get; set; } = new();

  public string? Description { get; set; }
}
