using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.ETL.Models;

internal class Customization
{
  public Guid Id { get; set; }

  public CustomizationKind Kind { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public static Customization Extract(Content content, ContentLocale locale)
  {
    Customization customization = new()
    {
      Id = content.EntityId,
      Kind = Enum.Parse<CustomizationKind>(content.Invariant.FindSelectValue(Customizations.Kind).Single()),
      Slug = locale.FindStringValue(Customizations.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Customizations.Summary),
      Description = locale.TryGetStringValue(Customizations.Description),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return customization;
  }

  public override bool Equals(object? obj) => obj is Attribute attribute && attribute.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
