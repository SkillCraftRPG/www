namespace SkillCraft.Cms.Core.Lineages.Models;

public record NamesModel
{
  public string? Text { get; set; }
  public List<string> Family { get; set; } = [];
  public List<string> Female { get; set; } = [];
  public List<string> Male { get; set; } = [];
  public List<string> Unisex { get; set; } = [];
  public List<NameCategory> Custom { get; set; } = [];
}
