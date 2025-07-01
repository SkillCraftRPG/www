using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.ETL.Models;

internal class Caste
{
  public Guid Id { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public Guid SkillId { get; set; }
  public string WealthRoll { get; set; } = string.Empty;

  public string? Feature { get; set; }

  public string? Notes { get; set; }

  public static Caste Extract(Content content, ContentLocale locale)
  {
    ContentLocale invariant = content.Invariant;

    Caste caste = new()
    {
      Id = content.EntityId,
      Slug = locale.FindStringValue(Castes.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Castes.Summary),
      Description = locale.TryGetStringValue(Castes.Description),
      SkillId = invariant.FindRelatedContentValue(Castes.Skill).Single(),
      WealthRoll = invariant.FindStringValue(Castes.WealthRoll),
      Feature = locale.TryGetStringValue(Castes.Feature),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return caste;
  }

  public override bool Equals(object? obj) => obj is Caste caste && caste.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
