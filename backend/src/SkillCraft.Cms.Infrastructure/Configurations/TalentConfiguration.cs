using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class TalentConfiguration : AggregateConfiguration<TalentEntity>, IEntityTypeConfiguration<TalentEntity>
{
  public override void Configure(EntityTypeBuilder<TalentEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Talents.Table.Table!, RulesDb.Talents.Table.Schema);
    builder.HasKey(x => x.TalentId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized).IsUnique();
    builder.HasIndex(x => x.Name);
    builder.HasIndex(x => x.Tier);
    builder.HasIndex(x => x.AllowMultiplePurchases);
    builder.HasIndex(x => x.SkillId);
    builder.HasIndex(x => x.SkillUid);
    builder.HasIndex(x => x.RequiredTalentId);
    builder.HasIndex(x => x.RequiredTalentUid);
    builder.HasIndex(x => x.Summary);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
    builder.Property(x => x.MetaDescription).HasMaxLength(Constants.MetaDescriptionMaximumLength);

    builder.HasOne(x => x.Skill).WithMany(x => x.Talents).OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(x => x.RequiredTalent).WithMany(x => x.RequiringTalents)
      .HasForeignKey(x => x.RequiredTalentId).HasPrincipalKey(x => x.TalentId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
