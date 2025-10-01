using Krakenar.Contracts;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Statistics.Models;

public class StatisticModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public AttributeModel Attribute { get; set; } = new();
  public GameStatistic Value { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }
}
