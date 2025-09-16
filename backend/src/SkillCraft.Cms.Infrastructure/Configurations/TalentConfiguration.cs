using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Cms.Core;
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
    builder.HasIndex(x => x.Skill);
    builder.HasIndex(x => x.RequiredTalentId);
    builder.HasIndex(x => x.RequiredTalentUid);
    builder.HasIndex(x => x.Summary);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.Skill).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<GameSkill>());
    builder.Property(x => x.Summary).HasMaxLength(160); // TODO(fpion): constant

    builder.HasOne(x => x.RequiredTalent).WithMany(x => x.RequiringTalents)
      .HasForeignKey(x => x.RequiredTalentId).HasPrincipalKey(x => x.TalentId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
