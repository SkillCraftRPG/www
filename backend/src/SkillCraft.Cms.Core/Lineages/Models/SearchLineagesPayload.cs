using Krakenar.Contracts.Search;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Lineages.Models;

public record SearchLineagesPayload : SearchPayload
{
  public Guid? ParentId { get; set; }
  public Guid? LanguageId { get; set; }
  public SizeCategory? SizeCategory { get; set; }

  public new List<LineageSortOption> Sort { get; set; } = [];
}
