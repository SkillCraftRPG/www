using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class EducationConfiguration : AggregateConfiguration<EducationEntity>, IEntityTypeConfiguration<EducationEntity>
{
  public override void Configure(EntityTypeBuilder<EducationEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Educations.Table.Table!, RulesDb.Educations.Table.Schema);
    builder.HasKey(x => x.EducationId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized).IsUnique();
    builder.HasIndex(x => x.Name);
    builder.HasIndex(x => x.SkillId);
    builder.HasIndex(x => x.SkillUid);
    builder.HasIndex(x => x.FeatureId);
    builder.HasIndex(x => x.FeatureUid);
    builder.HasIndex(x => x.Summary);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
    builder.Property(x => x.MetaDescription).HasMaxLength(Constants.MetaDescriptionMaximumLength);

    builder.HasOne(x => x.Skill).WithMany(x => x.Educations).OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(x => x.Feature).WithMany(x => x.Educations).OnDelete(DeleteBehavior.Restrict);
  }
}
