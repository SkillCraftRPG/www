using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Talents.Models;

public record SearchTalentsPayload : SearchPayload
{
  public List<string> Slugs { get; set; } = [];
  public List<int> Tiers { get; set; } = [];
  public bool? AllowMultiplePurchases { get; set; }
  // TODO(fpion): HasSkill, HasNoSkill, HasExactSkill, Skills?
  public Guid? RequiredTalentId { get; set; }

  public new List<TalentSortOption> Sort { get; set; } = [];
}
