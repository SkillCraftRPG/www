using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Castes.Models;

public record CasteSortOption : SortOption
{
  public new CasteSort Field
  {
    get => Enum.Parse<CasteSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public CasteSortOption() : this(CasteSort.Name)
  {
  }

  public CasteSortOption(CasteSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
