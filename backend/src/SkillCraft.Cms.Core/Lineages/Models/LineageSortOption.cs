using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Lineages.Models;

public record LineageSortOption : SortOption
{
  public new LineageSort Field
  {
    get => Enum.Parse<LineageSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public LineageSortOption() : this(LineageSort.Name)
  {
  }

  public LineageSortOption(LineageSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
