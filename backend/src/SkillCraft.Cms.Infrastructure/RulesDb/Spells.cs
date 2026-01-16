using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Spells
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Spells), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(SpellEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(SpellEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(SpellEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(SpellEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(SpellEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(SpellEntity.Version), Table);

  public static readonly ColumnId Description = new(nameof(SpellEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(SpellEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(SpellEntity.IsPublished), Table);
  public static readonly ColumnId MetaDescription = new(nameof(SpellEntity.MetaDescription), Table);
  public static readonly ColumnId Name = new(nameof(SpellEntity.Name), Table);
  public static readonly ColumnId Slug = new(nameof(SpellEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(SpellEntity.SlugNormalized), Table);
  public static readonly ColumnId SpellId = new(nameof(SpellEntity.SpellId), Table);
  public static readonly ColumnId Summary = new(nameof(SpellEntity.Summary), Table);
  public static readonly ColumnId Tier = new(nameof(SpellEntity.Tier), Table);
}
