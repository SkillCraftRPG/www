using Krakenar.Contracts;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Core.Statistics.Models;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Attributes.Models;

public class AttributeModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public AttributeCategory? Category { get; set; }
  public GameAttribute Value { get; set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public List<StatisticModel> Statistics { get; set; } = [];
  public List<SkillModel> Skills { get; set; } = [];
}
