using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Attributes.Models;

public record AttributeSortOption : SortOption
{
  public new AttributeSort Field
  {
    get => Enum.Parse<AttributeSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public AttributeSortOption() : this(AttributeSort.Name)
  {
  }

  public AttributeSortOption(AttributeSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
