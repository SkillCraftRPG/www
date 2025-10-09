using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Contracts;

namespace SkillCraft.Tools.Shared.Models;

public class AttributeDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public AttributeCategory? Category { get; set; }
  public GameAttribute Value { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public override bool Equals(object? obj) => obj is AttributeDto attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
