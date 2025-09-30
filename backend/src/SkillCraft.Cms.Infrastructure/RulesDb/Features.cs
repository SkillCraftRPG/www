using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Features
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Features), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(FeatureEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(FeatureEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(FeatureEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(FeatureEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(FeatureEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(FeatureEntity.Version), Table);

  public static readonly ColumnId Description = new(nameof(FeatureEntity.Description), Table);
  public static readonly ColumnId FeatureId = new(nameof(FeatureEntity.FeatureId), Table);
  public static readonly ColumnId Id = new(nameof(FeatureEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(FeatureEntity.IsPublished), Table);
  public static readonly ColumnId Name = new(nameof(FeatureEntity.Name), Table);
}
