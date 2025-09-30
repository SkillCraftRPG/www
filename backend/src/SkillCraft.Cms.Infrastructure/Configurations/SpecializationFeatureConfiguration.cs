using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class SpecializationFeatureConfiguration : IEntityTypeConfiguration<SpecializationFeatureEntity>
{
  public void Configure(EntityTypeBuilder<SpecializationFeatureEntity> builder)
  {
    builder.ToTable(RulesDb.SpecializationFeatures.Table.Table!, RulesDb.SpecializationFeatures.Table.Schema);
    builder.HasKey(x => new { x.SpecializationId, x.FeatureId });

    builder.HasIndex(x => x.SpecializationId);
    builder.HasIndex(x => x.SpecializationUid);
    builder.HasIndex(x => x.FeatureId);
    builder.HasIndex(x => x.FeatureUid);

    builder.HasOne(x => x.Specialization).WithMany(x => x.Features).OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(x => x.Feature).WithMany(x => x.Specializations);
  }
}
