using Krakenar.Contracts;

namespace SkillCraft.Cms.Core.Specializations.Models;

public class SpecializationModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public SpecializationRequirements Requirements { get; set; } = new();
  public SpecializationOptions Options { get; set; } = new();
  public ReservedTalent ReservedTalent { get; set; } = new(); // TODO(fpion): should be optional!
}
