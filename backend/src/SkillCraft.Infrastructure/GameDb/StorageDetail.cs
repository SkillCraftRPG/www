using Logitar.Data;

namespace SkillCraft.Infrastructure.GameDb;

internal static class StorageDetail
{
  public static readonly TableId Table = new(GameContext.Schema, nameof(GameContext.StorageDetail), alias: null);

  public static readonly ColumnId EntityId = new(nameof(Entities.StorageDetail.EntityId), Table);
  public static readonly ColumnId EntityKind = new(nameof(Entities.StorageDetail.EntityKind), Table);
  public static readonly ColumnId Key = new(nameof(Entities.StorageDetail.Key), Table);
  public static readonly ColumnId Size = new(nameof(Entities.StorageDetail.Size), Table);
  public static readonly ColumnId StorageDetailId = new(nameof(Entities.StorageDetail.StorageDetailId), Table);
  public static readonly ColumnId StoredBy = new(nameof(Entities.StorageDetail.StoredBy), Table);
  public static readonly ColumnId StoredOn = new(nameof(Entities.StorageDetail.StoredOn), Table);
  public static readonly ColumnId Version = new(nameof(Entities.StorageDetail.Version), Table);
  public static readonly ColumnId WorldId = new(nameof(Entities.StorageDetail.WorldId), Table);
  public static readonly ColumnId WorldUid = new(nameof(Entities.StorageDetail.WorldUid), Table);
}
