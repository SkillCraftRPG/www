using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Configurations.Rules;

internal class CustomizationConfiguration : AggregateConfiguration<CustomizationEntity>, IEntityTypeConfiguration<CustomizationEntity>
{
  public override void Configure(EntityTypeBuilder<CustomizationEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Rules.Customizations.Table.Table!, SkillCraftDb.Rules.Customizations.Table.Schema);
    builder.HasKey(x => x.CustomizationId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Slug).IsUnique();
    builder.HasIndex(x => x.Kind);

    builder.Property(x => x.Slug).HasMaxLength(Constants.SlugMaximumLength);
    builder.Property(x => x.Kind).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<CustomizationKind>());
    builder.Property(x => x.Name).HasMaxLength(Constants.NameMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
  }
}
