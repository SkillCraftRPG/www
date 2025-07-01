using Krakenar.Core.Contents;
using Logitar;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.Harvesting.Models;

internal class Skill
{
  public Guid Id { get; set; }
  public GameSkill Value { get; set; }

  public Guid? AttributeId { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public static Skill Extract(Content content, ContentLocale locale)
  {
    Skill skill = new()
    {
      Id = content.EntityId,
      Value = Enum.Parse<GameSkill>(locale.UniqueName.Value),
      AttributeId = content.Invariant.TryGetRelatedContentValue(Skills.Attribute)?.Single(),
      Slug = locale.FindStringValue(Skills.Slug),
      Name = locale.DisplayName?.Value ?? locale.UniqueName.Value,
      Summary = locale.TryGetStringValue(Skills.Summary),
      Description = locale.TryGetStringValue(Skills.Description),
      Notes = locale.Description?.Value?.CleanTrim()
    };
    return skill;
  }

  public override bool Equals(object? obj) => obj is Skill skill && skill.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
