using SkillCraft.Cms.Core.Languages.Models;

namespace SkillCraft.Cms.Core.Lineages.Models;

public record LanguagesModel
{
  public List<LanguageModel> Items { get; set; } = [];
  public int Extra { get; set; }
  public string? Text { get; set; }
}
