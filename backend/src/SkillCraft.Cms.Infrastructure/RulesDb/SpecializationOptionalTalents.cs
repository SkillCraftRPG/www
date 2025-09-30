using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class SpecializationOptionalTalents
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.SpecializationOptionalTalents), alias: null);

  public static readonly ColumnId SpecializationId = new(nameof(SpecializationOptionalTalentEntity.SpecializationId), Table);
  public static readonly ColumnId SpecializationUid = new(nameof(SpecializationOptionalTalentEntity.SpecializationUid), Table);
  public static readonly ColumnId TalentId = new(nameof(SpecializationOptionalTalentEntity.TalentId), Table);
  public static readonly ColumnId TalentUid = new(nameof(SpecializationOptionalTalentEntity.TalentUid), Table);
}
