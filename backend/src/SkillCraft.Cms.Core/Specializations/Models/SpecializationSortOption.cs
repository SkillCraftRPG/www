using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Specializations.Models;

public record SpecializationSortOption : SortOption
{
  public new SpecializationSort Field
  {
    get => Enum.Parse<SpecializationSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public SpecializationSortOption() : this(SpecializationSort.Name)
  {
  }

  public SpecializationSortOption(SpecializationSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
