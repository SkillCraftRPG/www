using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Customizations
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Customizations), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(CustomizationEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(CustomizationEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(CustomizationEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(CustomizationEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(CustomizationEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(CustomizationEntity.Version), Table);

  public static readonly ColumnId CustomizationId = new(nameof(CustomizationEntity.CustomizationId), Table);
  public static readonly ColumnId Description = new(nameof(CustomizationEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(CustomizationEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(CustomizationEntity.IsPublished), Table);
  public static readonly ColumnId Kind = new(nameof(CustomizationEntity.Kind), Table);
  public static readonly ColumnId MetaDescription = new(nameof(CustomizationEntity.MetaDescription), Table);
  public static readonly ColumnId Name = new(nameof(CustomizationEntity.Name), Table);
  public static readonly ColumnId Slug = new(nameof(CustomizationEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(CustomizationEntity.SlugNormalized), Table);
  public static readonly ColumnId Summary = new(nameof(CustomizationEntity.Summary), Table);
}
