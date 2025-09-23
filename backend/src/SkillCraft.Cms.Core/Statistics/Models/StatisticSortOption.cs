using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Statistics.Models;

public record StatisticSortOption : SortOption
{
  public new StatisticSort Field
  {
    get => Enum.Parse<StatisticSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public StatisticSortOption() : this(StatisticSort.Name)
  {
  }

  public StatisticSortOption(StatisticSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
