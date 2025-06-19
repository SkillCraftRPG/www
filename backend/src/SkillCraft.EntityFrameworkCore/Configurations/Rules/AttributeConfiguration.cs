using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Configurations.Rules;

internal class AttributeConfiguration : AggregateConfiguration<AttributeEntity>, IEntityTypeConfiguration<AttributeEntity>
{
  public override void Configure(EntityTypeBuilder<AttributeEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Rules.Attributes.Table.Table!, SkillCraftDb.Rules.Attributes.Table.Schema);
    builder.HasKey(x => x.AttributeId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Slug).IsUnique();
    builder.HasIndex(x => x.Value).IsUnique();

    builder.Property(x => x.Slug).HasMaxLength(Constants.SlugMaximumLength);
    builder.Property(x => x.Value).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<GameAttribute>());
    builder.Property(x => x.Name).HasMaxLength(Constants.NameMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
  }
}
