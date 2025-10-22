using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class LineageFeatureConfiguration : IEntityTypeConfiguration<LineageFeatureEntity>
{
  public void Configure(EntityTypeBuilder<LineageFeatureEntity> builder)
  {
    builder.ToTable(RulesDb.LineageFeatures.Table.Table!, RulesDb.LineageFeatures.Table.Schema);
    builder.HasKey(x => new { x.LineageId, x.FeatureId });

    builder.HasIndex(x => x.LineageId);
    builder.HasIndex(x => x.LineageUid);
    builder.HasIndex(x => x.FeatureId);
    builder.HasIndex(x => x.FeatureUid);

    builder.HasOne(x => x.Lineage).WithMany(x => x.Features).OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(x => x.Feature).WithMany(x => x.Lineages).OnDelete(DeleteBehavior.Restrict);
  }
}
