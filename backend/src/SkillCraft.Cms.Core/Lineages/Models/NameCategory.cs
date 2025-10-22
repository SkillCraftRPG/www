namespace SkillCraft.Cms.Core.Lineages.Models;

public record NameCategory
{
  public string Category { get; set; }
  public List<string> Values { get; set; }

  public NameCategory() : this(string.Empty)
  {
  }

  public NameCategory(string category, IEnumerable<string>? values = null)
  {
    Category = category;
    Values = values?.ToList() ?? [];
  }
}
