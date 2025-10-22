namespace SkillCraft.Cms.Core.Lineages.Models;

public record AgesModel
{
  public int Adolescent { get; set; }
  public int Adult { get; set; }
  public int Mature { get; set; }
  public int Venerable { get; set; }

  public AgesModel()
  {
  }

  public AgesModel(int adolescent, int adult, int mature, int venerable)
  {
    Adolescent = adolescent;
    Adult = adult;
    Mature = mature;
    Venerable = venerable;
  }
}
