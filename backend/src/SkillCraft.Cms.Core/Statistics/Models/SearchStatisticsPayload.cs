using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Statistics.Models;

public record SearchStatisticsPayload : SearchPayload
{
  // TODO(fpion): filters

  public new List<StatisticSortOption> Sort { get; set; } = [];
}
