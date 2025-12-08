namespace SkillCraft.Core.Worlds.Models;

public class UpdateWorldPayload
{
  public string? Name { get; set; }
  public Change<string>? Description { get; set; }

  public UpdateWorldPayload() : this(string.Empty)
  {
  }

  public UpdateWorldPayload(string name)
  {
    Name = name;
  }
}
