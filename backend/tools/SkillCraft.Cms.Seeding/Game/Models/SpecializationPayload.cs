namespace SkillCraft.Cms.Seeding.Game.Models;

internal record SpecializationPayload
{
  public Guid Id { get; set; }

  public int Tier { get; set; }
  public string Name { get; set; } = string.Empty;

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public SpecializationRequirements Requirements { get; set; } = new();
  public SpecializationOptions Options { get; set; } = new();

  public ReservedTalent ReservedTalent { get; set; } = new();
}

internal record SpecializationRequirements
{
  public string? Talent { get; set; }
  public List<string> Other { get; set; } = [];
}

internal record SpecializationOptions
{
  public string? Talents { get; set; }
  public List<string> Other { get; set; } = [];
}

public record ReservedTalent
{
  public string Name { get; set; } = string.Empty;
  public List<string> DiscountedTalents { get; set; } = [];
  public List<string> Description { get; set; } = [];
  public List<SpecializationFeature> Features { get; set; } = [];
}

public record SpecializationFeature
{
  public string Name { set; get; } = string.Empty;
  public string? Description { get; set; }
}
