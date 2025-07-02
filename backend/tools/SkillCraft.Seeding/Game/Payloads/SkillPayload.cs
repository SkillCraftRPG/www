using SkillCraft.Core;

namespace SkillCraft.Seeding.Game.Payloads;

public class SkillPayload
{
  public Guid Id { get; set; }
  public GameSkill Value { get; set; }

  public Guid? AttributeId { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is SkillPayload skill && skill.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
