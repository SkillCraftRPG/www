using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.ETL.Models;

internal class Attribute
{
  public Guid Id { get; set; }
  public GameAttribute Value { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public static Attribute Extract(Content content, ContentLocale locale)
  {
    Attribute attribute = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameAttribute>(locale.UniqueName.Value),
      Slug = locale.FindStringValue(Attributes.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Attributes.Summary),
      Description = locale.TryGetStringValue(Attributes.Description),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return attribute;
  }

  public override bool Equals(object? obj) => obj is Attribute attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
