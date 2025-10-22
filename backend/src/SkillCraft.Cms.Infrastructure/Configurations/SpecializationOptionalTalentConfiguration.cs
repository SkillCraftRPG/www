using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class SpecializationOptionalTalentConfiguration : IEntityTypeConfiguration<SpecializationOptionalTalentEntity>
{
  public void Configure(EntityTypeBuilder<SpecializationOptionalTalentEntity> builder)
  {
    builder.ToTable(RulesDb.SpecializationOptionalTalents.Table.Table!, RulesDb.SpecializationOptionalTalents.Table.Schema);
    builder.HasKey(x => new { x.SpecializationId, x.TalentId });

    builder.HasIndex(x => x.SpecializationId);
    builder.HasIndex(x => x.SpecializationUid);
    builder.HasIndex(x => x.TalentId);
    builder.HasIndex(x => x.TalentUid);

    builder.HasOne(x => x.Specialization).WithMany(x => x.OptionalTalents).OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(x => x.Talent).WithMany(x => x.SpecializationsOptional).OnDelete(DeleteBehavior.Restrict);
  }
}
