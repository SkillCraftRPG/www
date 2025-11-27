using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Configurations;

internal class StorageSummaryConfiguration : AggregateConfiguration<StorageSummary>, IEntityTypeConfiguration<StorageSummary>
{
  public override void Configure(EntityTypeBuilder<StorageSummary> builder)
  {
    base.Configure(builder);

    builder.ToTable(GameDb.StorageSummary.Table.Table!, GameDb.StorageSummary.Table.Schema);
    builder.HasKey(x => x.StorageSummaryId);

    builder.HasIndex(x => x.UserId).IsUnique();
    builder.HasIndex(x => x.AllocatedBytes);
    builder.HasIndex(x => x.UsedBytes);
    builder.HasIndex(x => x.AvailableBytes);
  }
}
