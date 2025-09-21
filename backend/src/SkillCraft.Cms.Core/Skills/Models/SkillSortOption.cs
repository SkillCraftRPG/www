using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Skills.Models;

public record SkillSortOption : SortOption
{
  public new SkillSort Field
  {
    get => Enum.Parse<SkillSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public SkillSortOption() : this(SkillSort.Name)
  {
  }

  public SkillSortOption(SkillSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
