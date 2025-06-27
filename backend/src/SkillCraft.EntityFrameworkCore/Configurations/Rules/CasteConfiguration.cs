using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Configurations.Rules;

internal class CasteConfiguration : AggregateConfiguration<CasteEntity>, IEntityTypeConfiguration<CasteEntity>
{
  public override void Configure(EntityTypeBuilder<CasteEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Rules.Castes.Table.Table!, SkillCraftDb.Rules.Castes.Table.Schema);
    builder.HasKey(x => x.CasteId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Slug).IsUnique();
    builder.HasIndex(x => x.SkillUid);
    builder.HasIndex(x => x.WealthRoll);

    builder.Property(x => x.Slug).HasMaxLength(Constants.SlugMaximumLength);
    builder.Property(x => x.Name).HasMaxLength(Constants.NameMaximumLength);
    builder.Property(x => x.Summary).HasMaxLength(Constants.SummaryMaximumLength);
    builder.Property(x => x.WealthRoll).HasMaxLength(Constants.RollMaximumLength);

    builder.HasOne(x => x.Skill).WithMany(x => x.Castes).OnDelete(DeleteBehavior.SetNull);
  }
}
