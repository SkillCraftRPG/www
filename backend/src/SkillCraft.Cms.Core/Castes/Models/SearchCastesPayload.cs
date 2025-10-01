using Krakenar.Contracts.Search;

namespace SkillCraft.Cms.Core.Castes.Models;

public record SearchCastesPayload : SearchPayload
{
  public new List<CasteSortOption> Sort { get; set; } = [];
}
