namespace SkillCraft.Tools.Shared.Models;

public record SpecializationRequirementsDto
{
  public RelationshipDto? Talent { get; set; }
  public List<string> Other { get; set; } = [];
}
