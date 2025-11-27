using Logitar.Data;

namespace SkillCraft.Infrastructure.GameDb;

internal static class StorageSummary
{
  public static readonly TableId Table = new(GameContext.Schema, nameof(GameContext.StorageSummary), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(Entities.StorageSummary.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(Entities.StorageSummary.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(Entities.StorageSummary.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(Entities.StorageSummary.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(Entities.StorageSummary.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(Entities.StorageSummary.Version), Table);

  public static readonly ColumnId AllocatedBytes = new(nameof(Entities.StorageSummary.AllocatedBytes), Table);
  public static readonly ColumnId AvailableBytes = new(nameof(Entities.StorageSummary.AvailableBytes), Table);
  public static readonly ColumnId StorageSummaryId = new(nameof(Entities.StorageSummary.StorageSummaryId), Table);
  public static readonly ColumnId UsedBytes = new(nameof(Entities.StorageSummary.UsedBytes), Table);
  public static readonly ColumnId UserId = new(nameof(Entities.StorageSummary.UserId), Table);
}
