namespace SkillCraft.Cms.Core.Lineages.Models;

public record AgeModel
{
  public int Teenager { get; set; }
  public int Adult { get; set; }
  public int Mature { get; set; }
  public int Venerable { get; set; }
  public string? Text { get; set; }

  public AgeModel()
  {
  }

  public AgeModel(int teenager, int adult, int mature, int venerable, string? text = null)
  {
    Teenager = teenager;
    Adult = adult;
    Mature = mature;
    Venerable = venerable;
    Text = text;
  }
}
