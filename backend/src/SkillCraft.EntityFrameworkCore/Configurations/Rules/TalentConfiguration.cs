using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Configurations.Rules;

internal class TalentConfiguration : AggregateConfiguration<TalentEntity>, IEntityTypeConfiguration<TalentEntity>
{
  public override void Configure(EntityTypeBuilder<TalentEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Rules.Talents.Table.Table!, SkillCraftDb.Rules.Talents.Table.Schema);
    builder.HasKey(x => x.TalentId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Slug).IsUnique();
    builder.HasIndex(x => x.Tier);
    builder.HasIndex(x => x.AllowMultiplePurchases);
    builder.HasIndex(x => x.SkillUid);
    builder.HasIndex(x => x.RequiredTalentUid);

    builder.Property(x => x.Slug).HasMaxLength(Constants.SlugMaximumLength);
    builder.Property(x => x.Name).HasMaxLength(Constants.NameMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);

    builder.HasOne(x => x.Skill).WithMany(x => x.Talents).OnDelete(DeleteBehavior.SetNull);
    builder.HasOne(x => x.RequiredTalent).WithMany(x => x.RequiringTalents)
      .HasPrincipalKey(x => x.TalentId).HasForeignKey(x => x.RequiredTalentId)
      .OnDelete(DeleteBehavior.SetNull);
  }
}
