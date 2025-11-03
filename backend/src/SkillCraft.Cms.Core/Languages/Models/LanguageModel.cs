using Krakenar.Contracts;
using SkillCraft.Cms.Core.Scripts.Models;

namespace SkillCraft.Cms.Core.Languages.Models;

public class LanguageModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public ScriptModel? Script { get; set; }
  public string? TypicalSpeakers { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
