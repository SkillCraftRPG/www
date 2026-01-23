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
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized).IsUnique();
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.MetaDescription).HasMaxLength(Constants.MetaDescriptionMaximumLength);
  }
}
