using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.ETL.Models;

internal class Statistic
{
  public Guid Id { get; set; }
  public GameStatistic Value { get; set; }

  public Guid AttributeId { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public static Statistic Extract(Content content, ContentLocale locale)
  {
    Statistic statistic = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameStatistic>(locale.UniqueName.Value),
      AttributeId = content.Invariant.FindRelatedContentValue(Statistics.Attribute).Single(),
      Slug = locale.FindStringValue(Statistics.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Statistics.Summary),
      Description = locale.TryGetStringValue(Statistics.Description),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return statistic;
  }

  public override bool Equals(object? obj) => obj is Statistic statistic && statistic.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
