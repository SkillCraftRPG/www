using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Statistics.Models;

namespace SkillCraft.Cms.Core.Statistics;

public interface IStatisticQuerier
{
  Task<StatisticModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<StatisticModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<StatisticModel>> SearchAsync(SearchStatisticsPayload payload, CancellationToken cancellationToken = default);
}
