using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Statistics.Models;

public record SearchStatisticsPayload : SearchPayload
{
  public new List<StatisticSortOption> Sort { get; set; } = [];
}
