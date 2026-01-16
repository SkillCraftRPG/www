using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Spells.Models;

public record SpellSortOption : SortOption
{
  public new SpellSort Field
  {
    get => Enum.Parse<SpellSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public SpellSortOption() : this(SpellSort.Name)
  {
  }

  public SpellSortOption(SpellSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
