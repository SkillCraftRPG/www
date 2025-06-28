using Logitar.Data;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.SkillCraftDb.Rules;

internal static class Castes
{
  public static readonly TableId Table = new(RuleContext.Schema, nameof(RuleContext.Castes), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(CasteEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(CasteEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(CasteEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(CasteEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(CasteEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(CasteEntity.Version), Table);

  public static readonly ColumnId CasteId = new(nameof(CasteEntity.CasteId), Table);
  public static readonly ColumnId Description = new(nameof(CasteEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(CasteEntity.Id), Table);
  public static readonly ColumnId Name = new(nameof(CasteEntity.Name), Table);
  public static readonly ColumnId SkillId = new(nameof(CasteEntity.SkillId), Table);
  public static readonly ColumnId SkillUid = new(nameof(CasteEntity.SkillUid), Table);
  public static readonly ColumnId Slug = new(nameof(CasteEntity.Slug), Table);
  public static readonly ColumnId Summary = new(nameof(CasteEntity.Summary), Table);
  public static readonly ColumnId WealthRoll = new(nameof(CasteEntity.WealthRoll), Table);
}
