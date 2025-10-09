namespace SkillCraft.Tools.Shared.Models;

public record RelationshipDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Slug { get; set; }
  public string Name { get; set; }

  public RelationshipDto() : this(string.Empty, string.Empty)
  {
  }

  public RelationshipDto(string slug, string name, bool isPublished = false, Guid? id = null)
  {
    Id = id ?? Guid.NewGuid();

    IsPublished = isPublished;

    Slug = slug;
    Name = name;
  }
}
