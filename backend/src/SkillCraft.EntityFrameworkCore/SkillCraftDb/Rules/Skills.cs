using Logitar.Data;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.SkillCraftDb.Rules;

internal static class Skills
{
  public static readonly TableId Table = new(RuleContext.Schema, nameof(RuleContext.Skills), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(SkillEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(SkillEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(SkillEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(SkillEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(SkillEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(SkillEntity.Version), Table);

  public static readonly ColumnId AttributeId = new(nameof(SkillEntity.AttributeId), Table);
  public static readonly ColumnId AttributeUid = new(nameof(SkillEntity.AttributeUid), Table);
  public static readonly ColumnId Description = new(nameof(SkillEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(SkillEntity.Id), Table);
  public static readonly ColumnId Name = new(nameof(SkillEntity.Name), Table);
  public static readonly ColumnId SkillId = new(nameof(SkillEntity.SkillId), Table);
  public static readonly ColumnId Slug = new(nameof(SkillEntity.Slug), Table);
  public static readonly ColumnId Summary = new(nameof(SkillEntity.Summary), Table);
  public static readonly ColumnId Value = new(nameof(SkillEntity.Value), Table);
}
