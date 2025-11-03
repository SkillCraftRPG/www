using Krakenar.Contracts;
using SkillCraft.Cms.Core.Languages.Models;

namespace SkillCraft.Cms.Core.Scripts.Models;

public class ScriptModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public List<LanguageModel> Languages { get; set; } = [];

  public override string ToString() => $"{Name} | {base.ToString()}";
}
