using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class LineageConfiguration : AggregateConfiguration<LineageEntity>, IEntityTypeConfiguration<LineageEntity>
{
  public override void Configure(EntityTypeBuilder<LineageEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Lineages.Table.Table!, RulesDb.Lineages.Table.Schema);
    builder.HasKey(x => x.LineageId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized).IsUnique();
    builder.HasIndex(x => x.Name);
    builder.HasIndex(x => x.ParentId);
    builder.HasIndex(x => x.ParentUid);
    builder.HasIndex(x => x.SizeCategory);
    builder.HasIndex(x => x.Summary);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.SizeCategory).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<SizeCategory>());
    builder.Property(x => x.SizeRoll).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.Malnutrition).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.Skinny).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.NormalWeight).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.Overweight).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.Obese).HasMaxLength(Constants.RollMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
    builder.Property(x => x.MetaDescription).HasMaxLength(Constants.MetaDescriptionMaximumLength);

    builder.HasOne(x => x.Parent).WithMany(x => x.Children)
      .HasForeignKey(x => x.ParentId).HasPrincipalKey(x => x.LineageId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
