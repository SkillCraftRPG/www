using AggregateModel = Krakenar.Contracts.Aggregate;

namespace SkillCraft.Core.Worlds.Models;

public class WorldModel : AggregateModel
{
  public string Slug { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }

  public WorldModel() : this(string.Empty, string.Empty)
  {
  }

  public WorldModel(string slug, string name)
  {
    Slug = slug;
    Name = name;
  }
}
