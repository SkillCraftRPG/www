using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Articles
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Articles), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(ArticleEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(ArticleEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(ArticleEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(ArticleEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(ArticleEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(ArticleEntity.Version), Table);

  public static readonly ColumnId ArticleId = new(nameof(ArticleEntity.ArticleId), Table);
  public static readonly ColumnId CollectionId = new(nameof(ArticleEntity.CollectionId), Table);
  public static readonly ColumnId CollectionUid = new(nameof(ArticleEntity.CollectionUid), Table);
  public static readonly ColumnId HtmlContent = new(nameof(ArticleEntity.HtmlContent), Table);
  public static readonly ColumnId Id = new(nameof(ArticleEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(ArticleEntity.IsPublished), Table);
  public static readonly ColumnId MetaDescription = new(nameof(ArticleEntity.MetaDescription), Table);
  public static readonly ColumnId ParentId = new(nameof(ArticleEntity.ParentId), Table);
  public static readonly ColumnId ParentUid = new(nameof(ArticleEntity.ParentUid), Table);
  public static readonly ColumnId Slug = new(nameof(ArticleEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(ArticleEntity.SlugNormalized), Table);
  public static readonly ColumnId Title = new(nameof(ArticleEntity.Title), Table);
}
