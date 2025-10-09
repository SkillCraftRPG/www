using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Models;

internal record SpecializationOptionsDto
{
  public List<RelationshipDto> Talents { get; set; } = [];
  public List<string> Other { get; set; } = [];
}
