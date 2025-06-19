using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Configurations.Rules;

internal class SkillConfiguration : AggregateConfiguration<SkillEntity>, IEntityTypeConfiguration<SkillEntity>
{
  public override void Configure(EntityTypeBuilder<SkillEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Rules.Skills.Table.Table!, SkillCraftDb.Rules.Skills.Table.Schema);
    builder.HasKey(x => x.SkillId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Slug).IsUnique();
    builder.HasIndex(x => x.Value).IsUnique();
    builder.HasIndex(x => x.AttributeUid);

    builder.Property(x => x.Slug).HasMaxLength(Constants.SlugMaximumLength);
    builder.Property(x => x.Value).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<GameSkill>());
    builder.Property(x => x.Name).HasMaxLength(Constants.NameMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);

    builder.HasOne(x => x.Attribute).WithMany(x => x.Skills).OnDelete(DeleteBehavior.SetNull);
  }
}
