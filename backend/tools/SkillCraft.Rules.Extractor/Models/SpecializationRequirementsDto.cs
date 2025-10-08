namespace SkillCraft.Rules.Extractor.Models;

internal record SpecializationRequirementsDto
{
  public RelationshipDto? Talent { get; set; }
  public List<string> Other { get; set; } = [];
}
