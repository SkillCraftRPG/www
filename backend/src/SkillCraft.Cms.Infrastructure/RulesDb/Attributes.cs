using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Attributes
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Attributes), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(AttributeEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(AttributeEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(AttributeEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(AttributeEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(AttributeEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(AttributeEntity.Version), Table);

  public static readonly ColumnId AttributeId = new(nameof(AttributeEntity.AttributeId), Table);
  public static readonly ColumnId Category = new(nameof(AttributeEntity.Category), Table);
  public static readonly ColumnId Description = new(nameof(AttributeEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(AttributeEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(AttributeEntity.IsPublished), Table);
  public static readonly ColumnId MetaDescription = new(nameof(AttributeEntity.MetaDescription), Table);
  public static readonly ColumnId Name = new(nameof(AttributeEntity.Name), Table);
  public static readonly ColumnId Slug = new(nameof(AttributeEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(AttributeEntity.SlugNormalized), Table);
  public static readonly ColumnId Summary = new(nameof(AttributeEntity.Summary), Table);
  public static readonly ColumnId Value = new(nameof(AttributeEntity.Value), Table);
}
