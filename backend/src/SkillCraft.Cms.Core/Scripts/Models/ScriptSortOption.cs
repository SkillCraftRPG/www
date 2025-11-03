using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Scripts.Models;

public record ScriptSortOption : SortOption
{
  public new ScriptSort Field
  {
    get => Enum.Parse<ScriptSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public ScriptSortOption() : this(ScriptSort.Name)
  {
  }

  public ScriptSortOption(ScriptSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
