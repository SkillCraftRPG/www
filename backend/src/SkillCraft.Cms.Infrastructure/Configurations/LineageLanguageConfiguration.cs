using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class LineageLanguageConfiguration : IEntityTypeConfiguration<LineageLanguageEntity>
{
  public void Configure(EntityTypeBuilder<LineageLanguageEntity> builder)
  {
    builder.ToTable(RulesDb.LineageLanguages.Table.Table!, RulesDb.LineageLanguages.Table.Schema);
    builder.HasKey(x => new { x.LineageId, x.LanguageId });

    builder.HasIndex(x => x.LineageId);
    builder.HasIndex(x => x.LineageUid);
    builder.HasIndex(x => x.LanguageId);
    builder.HasIndex(x => x.LanguageUid);

    builder.HasOne(x => x.Lineage).WithMany(x => x.Languages).OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(x => x.Language).WithMany(x => x.Lineages).OnDelete(DeleteBehavior.Restrict);
  }
}
