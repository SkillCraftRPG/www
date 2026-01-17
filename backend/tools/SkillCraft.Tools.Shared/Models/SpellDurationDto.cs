using SkillCraft.Contracts;

namespace SkillCraft.Tools.Shared.Models;

public record SpellDurationDto
{
  public int Value { get; set; }
  public DurationUnit Unit { get; set; }
  public bool Concentration { get; set; }
}
