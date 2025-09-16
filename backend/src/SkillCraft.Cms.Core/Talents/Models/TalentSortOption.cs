using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Talents.Models;

public record TalentSortOption : SortOption
{
  public new TalentSort Field
  {
    get => Enum.Parse<TalentSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public TalentSortOption() : this(TalentSort.Name)
  {
  }

  public TalentSortOption(TalentSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
