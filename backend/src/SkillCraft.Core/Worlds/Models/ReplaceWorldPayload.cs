namespace SkillCraft.Core.Worlds.Models;

public class ReplaceWorldPayload
{
  public string Name { get; set; }
  public string? Description { get; set; }

  public ReplaceWorldPayload() : this(string.Empty)
  {
  }

  public ReplaceWorldPayload(string name)
  {
    Name = name;
  }
}
