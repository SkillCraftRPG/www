using Krakenar.Contracts;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Core.Customizations.Models;

public class CustomizationModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public CustomizationKind Kind { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
