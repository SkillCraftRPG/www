using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Lineages.Models;

public record SizeModel
{
  public SizeCategory Category { get; set; }
  public string? Roll { get; set; }

  public SizeModel()
  {
  }

  public SizeModel(SizeCategory category, string? roll = null)
  {
    Category = category;
    Roll = roll;
  }
}
