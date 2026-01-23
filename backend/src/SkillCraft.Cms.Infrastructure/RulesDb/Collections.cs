using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Collections
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Collections), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(CollectionEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(CollectionEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(CollectionEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(CollectionEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(CollectionEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(CollectionEntity.Version), Table);

  public static readonly ColumnId CollectionId = new(nameof(CollectionEntity.CollectionId), Table);
  public static readonly ColumnId Description = new(nameof(CollectionEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(CollectionEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(CollectionEntity.IsPublished), Table);
  public static readonly ColumnId Key = new(nameof(CollectionEntity.Key), Table);
  public static readonly ColumnId KeyNormalized = new(nameof(CollectionEntity.KeyNormalized), Table);
  public static readonly ColumnId Name = new(nameof(CollectionEntity.Name), Table);
}
