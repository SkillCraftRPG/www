using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class SpecializationFeatures
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.SpecializationFeatures), alias: null);

  public static readonly ColumnId FeatureId = new(nameof(SpecializationFeatureEntity.FeatureId), Table);
  public static readonly ColumnId FeatureUid = new(nameof(SpecializationFeatureEntity.FeatureUid), Table);
  public static readonly ColumnId SpecializationId = new(nameof(SpecializationFeatureEntity.SpecializationId), Table);
  public static readonly ColumnId SpecializationUid = new(nameof(SpecializationFeatureEntity.SpecializationUid), Table);
}
