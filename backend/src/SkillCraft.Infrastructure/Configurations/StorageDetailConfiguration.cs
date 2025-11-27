using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Configurations;

internal class StorageDetailConfiguration : IEntityTypeConfiguration<StorageDetail>
{
  public void Configure(EntityTypeBuilder<StorageDetail> builder)
  {
    builder.ToTable(GameDb.StorageDetail.Table.Table!, GameDb.StorageDetail.Table.Schema);
    builder.HasKey(x => x.StorageDetailId);

    builder.HasIndex(x => x.Key).IsUnique();
    builder.HasIndex(x => x.WorldId);
    builder.HasIndex(x => x.WorldUid);
    builder.HasIndex(x => x.EntityKind);
    builder.HasIndex(x => x.EntityId);
    builder.HasIndex(x => x.Size);
    builder.HasIndex(x => x.Version);
    builder.HasIndex(x => x.StoredBy);
    builder.HasIndex(x => x.StoredOn);

    builder.Property(x => x.Key).HasMaxLength(StreamId.MaximumLength);
    builder.Property(x => x.EntityKind).HasMaxLength(EntityKind.MaximumLength);
    builder.Property(x => x.StoredBy).HasMaxLength(ActorId.MaximumLength);

    builder.HasOne(x => x.World).WithMany(x => x.StorageDetail).OnDelete(DeleteBehavior.Cascade);
  }
}
