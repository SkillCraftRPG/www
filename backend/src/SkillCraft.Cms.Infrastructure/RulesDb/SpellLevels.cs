using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class SpellLevels
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.SpellLevels), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(SpellLevelEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(SpellLevelEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(SpellLevelEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(SpellLevelEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(SpellLevelEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(SpellLevelEntity.Version), Table);

  public static readonly ColumnId CastingTime = new(nameof(SpellLevelEntity.CastingTime), Table);
  public static readonly ColumnId Description = new(nameof(SpellLevelEntity.Description), Table);
  public static readonly ColumnId Duration = new(nameof(SpellLevelEntity.Duration), Table);
  public static readonly ColumnId DurationUnit = new(nameof(SpellLevelEntity.DurationUnit), Table);
  public static readonly ColumnId Focus = new(nameof(SpellLevelEntity.Focus), Table);
  public static readonly ColumnId Id = new(nameof(SpellLevelEntity.Id), Table);
  public static readonly ColumnId IsConcentration = new(nameof(SpellLevelEntity.IsConcentration), Table);
  public static readonly ColumnId IsPublished = new(nameof(SpellLevelEntity.IsPublished), Table);
  public static readonly ColumnId IsRitual = new(nameof(SpellLevelEntity.IsRitual), Table);
  public static readonly ColumnId IsSomatic = new(nameof(SpellLevelEntity.IsSomatic), Table);
  public static readonly ColumnId IsVerbal = new(nameof(SpellLevelEntity.IsVerbal), Table);
  public static readonly ColumnId Level = new(nameof(SpellLevelEntity.Level), Table);
  public static readonly ColumnId Material = new(nameof(SpellLevelEntity.Material), Table);
  public static readonly ColumnId Name = new(nameof(SpellLevelEntity.Name), Table);
  public static readonly ColumnId Range = new(nameof(SpellLevelEntity.Range), Table);
  public static readonly ColumnId SpellId = new(nameof(SpellLevelEntity.SpellId), Table);
  public static readonly ColumnId SpellLevelId = new(nameof(SpellLevelEntity.SpellLevelId), Table);
  public static readonly ColumnId SpellUid = new(nameof(SpellLevelEntity.SpellUid), Table);
}
