namespace SkillCraft.Rules.Extractor.Models;

internal record ReservedTalentDto
{
  public string Name { get; set; }
  public List<string> Description { get; set; } = [];
  public List<RelationshipDto> DiscountedTalents { get; set; } = [];
  public List<FeatureDto> Features { get; set; } = [];

  public ReservedTalentDto() : this(string.Empty)
  {
  }

  public ReservedTalentDto(string name)
  {
    Name = name;
  }
}
