using Krakenar.Contracts;

namespace SkillCraft.Core.Rules.Models;

public class AttributeModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public GameAttribute Value { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public List<SkillModel> Skills { get; set; } = [];
  public List<StatisticModel> Statistics { get; set; } = [];
}
