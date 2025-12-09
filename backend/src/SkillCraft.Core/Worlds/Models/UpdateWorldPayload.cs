namespace SkillCraft.Core.Worlds.Models;

public class UpdateWorldPayload
{
  public string? Name { get; set; }
  public Change<string>? Description { get; set; }
}
