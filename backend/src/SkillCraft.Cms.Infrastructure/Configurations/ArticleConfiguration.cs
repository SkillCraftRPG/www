using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class ArticleConfiguration : AggregateConfiguration<ArticleEntity>, IEntityTypeConfiguration<ArticleEntity>
{
  public override void Configure(EntityTypeBuilder<ArticleEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Articles.Table.Table!, RulesDb.Articles.Table.Schema);
    builder.HasKey(x => x.ArticleId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.CollectionId);
    builder.HasIndex(x => x.CollectionUid);
    builder.HasIndex(x => x.ParentId);
    builder.HasIndex(x => x.ParentUid);
    builder.HasIndex(x => x.Slug);
    builder.HasIndex(x => x.SlugNormalized);
    builder.HasIndex(x => x.Title);

    builder.Property(x => x.Slug).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.SlugNormalized).HasMaxLength(UniqueName.MaximumLength);
    builder.Property(x => x.Title).HasMaxLength(DisplayName.MaximumLength);
    builder.Property(x => x.MetaDescription).HasMaxLength(Constants.MetaDescriptionMaximumLength);

    builder.HasOne(x => x.Collection).WithMany(x => x.Articles).OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(x => x.Parent).WithMany(x => x.Children)
      .HasForeignKey(x => x.ParentId).HasPrincipalKey(x => x.ArticleId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
