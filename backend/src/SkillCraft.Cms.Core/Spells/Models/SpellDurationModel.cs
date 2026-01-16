using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Spells.Models;

public record SpellDurationModel
{
  public int Value { get; set; }
  public DurationUnit Unit { get; set; }
  public bool IsConcentration { get; set; }
}
