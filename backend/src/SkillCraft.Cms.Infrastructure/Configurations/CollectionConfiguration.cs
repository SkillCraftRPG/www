using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class CollectionConfiguration : AggregateConfiguration<CollectionEntity>, IEntityTypeConfiguration<CollectionEntity>
{
  public override void Configure(EntityTypeBuilder<CollectionEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Collections.Table.Table!, RulesDb.Collections.Table.Schema);
    builder.HasKey(x => x.CollectionId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Key);
    builder.HasIndex(x => x.KeyNormalized).IsUnique();
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Key).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.KeyNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
  }
}
