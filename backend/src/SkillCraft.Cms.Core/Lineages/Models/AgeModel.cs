namespace SkillCraft.Cms.Core.Lineages.Models;

public record AgeModel
{
  public int Teenager { get; set; }
  public int Adult { get; set; }
  public int Mature { get; set; }
  public int Venerable { get; set; }

  public AgeModel()
  {
  }

  public AgeModel(int teenager, int adult, int mature, int venerable)
  {
    Teenager = teenager;
    Adult = adult;
    Mature = mature;
    Venerable = venerable;
  }
}
