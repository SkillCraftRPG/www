using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.Harvesting.Models;

internal class Education
{
  public Guid Id { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public Guid SkillId { get; set; }
  public int WealthMultiplier { get; set; }

  public string? Feature { get; set; }

  public string? Notes { get; set; }

  public static Education Extract(Content content, ContentLocale locale)
  {
    ContentLocale invariant = content.Invariant;

    Education education = new()
    {
      Id = content.EntityId,
      Slug = locale.FindStringValue(Educations.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Educations.Summary),
      Description = locale.TryGetStringValue(Educations.Description),
      SkillId = invariant.FindRelatedContentValue(Educations.Skill).Single(),
      WealthMultiplier = (int)invariant.FindNumberValue(Educations.WealthMultiplier),
      Feature = locale.TryGetStringValue(Educations.Feature),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return education;
  }

  public override bool Equals(object? obj) => obj is Education education && education.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
