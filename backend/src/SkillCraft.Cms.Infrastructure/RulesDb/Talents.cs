using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Talents
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Talents), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(TalentEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(TalentEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(TalentEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(TalentEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(TalentEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(TalentEntity.Version), Table);

  public static readonly ColumnId AllowMultiplePurchases = new(nameof(TalentEntity.AllowMultiplePurchases), Table);
  public static readonly ColumnId Description = new(nameof(TalentEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(TalentEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(TalentEntity.IsPublished), Table);
  public static readonly ColumnId Name = new(nameof(TalentEntity.Name), Table);
  public static readonly ColumnId RequiredTalentId = new(nameof(TalentEntity.RequiredTalentId), Table);
  public static readonly ColumnId RequiredTalentUid = new(nameof(TalentEntity.RequiredTalentUid), Table);
  public static readonly ColumnId SkillId = new(nameof(TalentEntity.SkillId), Table);
  public static readonly ColumnId SkillUid = new(nameof(TalentEntity.SkillUid), Table);
  public static readonly ColumnId Slug = new(nameof(TalentEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(TalentEntity.SlugNormalized), Table);
  public static readonly ColumnId Summary = new(nameof(TalentEntity.Summary), Table);
  public static readonly ColumnId TalentId = new(nameof(TalentEntity.TalentId), Table);
  public static readonly ColumnId Tier = new(nameof(TalentEntity.Tier), Table);
}
