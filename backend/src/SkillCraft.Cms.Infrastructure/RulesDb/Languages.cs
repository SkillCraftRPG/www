using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Languages
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Languages), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(LanguageEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(LanguageEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(LanguageEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(LanguageEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(LanguageEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(LanguageEntity.Version), Table);

  public static readonly ColumnId Description = new(nameof(LanguageEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(LanguageEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(LanguageEntity.IsPublished), Table);
  public static readonly ColumnId LanguageId = new(nameof(LanguageEntity.LanguageId), Table);
  public static readonly ColumnId MetaDescription = new(nameof(LanguageEntity.MetaDescription), Table);
  public static readonly ColumnId Name = new(nameof(LanguageEntity.Name), Table);
  public static readonly ColumnId Slug = new(nameof(LanguageEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(LanguageEntity.SlugNormalized), Table);
  public static readonly ColumnId Summary = new(nameof(LanguageEntity.Summary), Table);
}
