namespace SkillCraft.Tools.Shared.Models;

public record SpecializationOptionsDto
{
  public List<RelationshipDto> Talents { get; set; } = [];
  public List<string> Other { get; set; } = [];
}
