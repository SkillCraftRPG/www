using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Statistics
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Statistics), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(StatisticEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(StatisticEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(StatisticEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(StatisticEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(StatisticEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(StatisticEntity.Version), Table);

  public static readonly ColumnId AttributeId = new(nameof(StatisticEntity.AttributeId), Table);
  public static readonly ColumnId AttributeUid = new(nameof(StatisticEntity.AttributeUid), Table);
  public static readonly ColumnId Description = new(nameof(StatisticEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(StatisticEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(StatisticEntity.IsPublished), Table);
  public static readonly ColumnId Name = new(nameof(StatisticEntity.Name), Table);
  public static readonly ColumnId Slug = new(nameof(StatisticEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(StatisticEntity.SlugNormalized), Table);
  public static readonly ColumnId StatisticId = new(nameof(StatisticEntity.StatisticId), Table);
  public static readonly ColumnId Summary = new(nameof(StatisticEntity.Summary), Table);
  public static readonly ColumnId Value = new(nameof(StatisticEntity.Value), Table);
}
