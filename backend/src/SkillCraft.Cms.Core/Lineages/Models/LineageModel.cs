using Krakenar.Contracts;
using SkillCraft.Cms.Core.Features.Models;

namespace SkillCraft.Cms.Core.Lineages.Models;

public class LineageModel : Aggregate
{
  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public LanguagesModel Languages { get; set; } = new();
  public NamesModel Names { get; set; } = new();

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public SpeedsModel Speeds { get; set; } = new();
  public SizeModel Size { get; set; } = new();
  public WeightsModel Weights { get; set; } = new();
  public AgesModel Ages { get; set; } = new();

  public LineageModel? Parent { get; set; }
  public List<LineageModel> Children { get; set; } = [];
  public List<FeatureModel> Features { get; set; } = [];

  public override string ToString() => $"{Name} | {base.ToString()}";
}
