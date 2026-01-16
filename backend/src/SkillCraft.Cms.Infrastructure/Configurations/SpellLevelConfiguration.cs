using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class SpellLevelConfiguration : AggregateConfiguration<SpellLevelEntity>, IEntityTypeConfiguration<SpellLevelEntity>
{
  private const int CastingTimeMaximumLength = 8;
  private const int IngredientMaximumLength = 1024;

  public override void Configure(EntityTypeBuilder<SpellLevelEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.SpellLevels.Table.Table!, RulesDb.SpellLevels.Table.Schema);
    builder.HasKey(x => x.SpellLevelId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.SpellId);
    builder.HasIndex(x => x.SpellUid);

    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.CastingTime).HasMaxLength(CastingTimeMaximumLength);
    builder.Property(x => x.DurationUnit).HasMaxLength(byte.MaxValue).HasConversion(new EnumToStringConverter<DurationUnit>());
    builder.Property(x => x.Focus).HasMaxLength(IngredientMaximumLength);
    builder.Property(x => x.Material).HasMaxLength(IngredientMaximumLength);

    builder.HasOne(x => x.Spell).WithMany(x => x.Levels).OnDelete(DeleteBehavior.NoAction);
  }
}
