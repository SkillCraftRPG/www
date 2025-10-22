namespace SkillCraft.Cms.Core.Lineages.Models;

public record WeightModel
{
  public string? Malnutrition { get; set; }
  public string? Skinny { get; set; }
  public string? Normal { get; set; }
  public string? Overweight { get; set; }
  public string? Obese { get; set; }

  public WeightModel()
  {
  }

  public WeightModel(string? malnutrition, string? skinny, string? normal, string? overweight, string? obese)
  {
    Malnutrition = malnutrition;
    Skinny = skinny;
    Normal = normal;
    Overweight = overweight;
    Obese = obese;
  }
}
