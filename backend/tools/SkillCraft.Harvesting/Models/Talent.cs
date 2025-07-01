using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.Harvesting.Models;

internal class Talent
{
  public Guid Id { get; set; }

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public Guid? SkillId { get; set; }
  public Guid? RequiredTalentId { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public static Talent Extract(Content content, ContentLocale locale)
  {
    ContentLocale invariant = content.Invariant;

    Talent talent = new()
    {
      Id = content.EntityId,
      Tier = (int)invariant.FindNumberValue(Talents.Tier),
      AllowMultiplePurchases = invariant.GetBooleanValue(Talents.AllowMultiplePurchases),
      SkillId = invariant.TryGetRelatedContentValue(Talents.Skill)?.Single(),
      RequiredTalentId = invariant.TryGetRelatedContentValue(Talents.RequiredTalent)?.Single(),
      Slug = locale.FindStringValue(Talents.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Talents.Summary),
      Description = locale.TryGetStringValue(Talents.Description),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return talent;
  }

  public override bool Equals(object? obj) => obj is Talent talent && talent.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
