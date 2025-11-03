namespace SkillCraft.Cms.Core.Lineages.Models;

public record SpeedsModel
{
  public int Walk { get; set; }
  public int Climb { get; set; }
  public int Swim { get; set; }
  public int Fly { get; set; }
  public bool Hover { get; set; }
  public int Burrow { get; set; }

  public SpeedsModel()
  {
  }

  public SpeedsModel(int walk, int climb, int swim, int fly, int burrow, bool hover = false)
  {
    Walk = walk;
    Climb = climb;
    Swim = swim;
    Fly = fly;
    Hover = hover;
    Burrow = burrow;
  }
}
