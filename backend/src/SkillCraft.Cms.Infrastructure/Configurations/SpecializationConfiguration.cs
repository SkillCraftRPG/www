using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class SpecializationConfiguration : AggregateConfiguration<SpecializationEntity>, IEntityTypeConfiguration<SpecializationEntity>
{
  public override void Configure(EntityTypeBuilder<SpecializationEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Specializations.Table.Table!, RulesDb.Specializations.Table.Schema);
    builder.HasKey(x => x.SpecializationId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized).IsUnique();
    builder.HasIndex(x => x.Name);
    builder.HasIndex(x => x.Tier);
    builder.HasIndex(x => x.Summary);
    builder.HasIndex(x => x.MandatoryTalentId);
    builder.HasIndex(x => x.MandatoryTalentUid);
    builder.HasIndex(x => x.ReservedTalentName);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
    builder.Property(x => x.ReservedTalentName).HasMaxLength(DisplayName.MaximumLength);

    builder.HasOne(x => x.MandatoryTalent).WithMany(x => x.SpecializationsMandatory)
      .HasForeignKey(x => x.MandatoryTalentId).HasPrincipalKey(x => x.TalentId)
      .OnDelete(DeleteBehavior.Restrict);
    builder.HasMany(x => x.OptionalTalents).WithMany(x => x.SpecializationsOptional);
    builder.HasMany(x => x.DiscountedTalents).WithMany(x => x.SpecializationsDiscounted);
  }
}
