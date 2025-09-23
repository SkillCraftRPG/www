using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Statistics.Models;

namespace SkillCraft.Cms.Models.Statistic;

public record SearchStatisticsParameters : SearchParameters
{
  public virtual SearchStatisticsPayload ToPayload()
  {
    SearchStatisticsPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out StatisticSort field))
      {
        payload.Sort.Add(new StatisticSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}
