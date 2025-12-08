namespace SkillCraft.Core.Worlds.Models;

public class CreateWorldPayload
{
  public string Slug { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }

  public CreateWorldPayload() : this(string.Empty, string.Empty)
  {
  }

  public CreateWorldPayload(string slug, string name)
  {
    Slug = slug;
    Name = name;
  }
}
