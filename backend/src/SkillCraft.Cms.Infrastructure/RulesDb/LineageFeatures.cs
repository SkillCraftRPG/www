using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class LineageFeatures
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.LineageFeatures), alias: null);

  public static readonly ColumnId FeatureId = new(nameof(LineageFeatureEntity.FeatureId), Table);
  public static readonly ColumnId FeatureUid = new(nameof(LineageFeatureEntity.FeatureUid), Table);
  public static readonly ColumnId LineageId = new(nameof(LineageFeatureEntity.LineageId), Table);
  public static readonly ColumnId LineageUid = new(nameof(LineageFeatureEntity.LineageUid), Table);
}
