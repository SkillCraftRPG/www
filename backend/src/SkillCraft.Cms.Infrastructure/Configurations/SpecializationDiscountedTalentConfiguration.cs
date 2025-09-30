using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class SpecializationDiscountedTalentConfiguration : IEntityTypeConfiguration<SpecializationDiscountedTalentEntity>
{
  public void Configure(EntityTypeBuilder<SpecializationDiscountedTalentEntity> builder)
  {
    builder.ToTable(RulesDb.SpecializationDiscountedTalents.Table.Table!, RulesDb.SpecializationDiscountedTalents.Table.Schema);
    builder.HasKey(x => new { x.SpecializationId, x.TalentId });

    builder.HasIndex(x => x.SpecializationId);
    builder.HasIndex(x => x.SpecializationUid);
    builder.HasIndex(x => x.TalentId);
    builder.HasIndex(x => x.TalentUid);

    builder.HasOne(x => x.Specialization).WithMany(x => x.DiscountedTalents).OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(x => x.Talent).WithMany(x => x.SpecializationsDiscounted);
  }
}
