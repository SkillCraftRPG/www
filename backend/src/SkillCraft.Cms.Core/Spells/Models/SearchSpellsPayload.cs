using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Spells.Models;

public record SearchSpellsPayload : SearchPayload
{
  public List<string> Slugs { get; set; } = [];
  public List<int> Tiers { get; set; } = [];

  public new List<SpellSortOption> Sort { get; set; } = [];
}
