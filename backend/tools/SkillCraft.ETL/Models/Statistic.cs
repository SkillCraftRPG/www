using SkillCraft.Core;

namespace SkillCraft.ETL.Models;

internal class Statistic
{
  public Guid Id { get; set; }

  public Guid AttributeId { get; set; }
  public GameStatistic Value { get; set; }

  public string Name { get; set; } = string.Empty;
  public string? Summary { get; set; }
  public string? Description { get; set; }

  public string? Notes { get; set; }

  public override bool Equals(object? obj) => obj is Statistic statistic && statistic.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
