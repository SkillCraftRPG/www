using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Configurations;

internal class FeatureConfiguration : AggregateConfiguration<FeatureEntity>, IEntityTypeConfiguration<FeatureEntity>
{
  public override void Configure(EntityTypeBuilder<FeatureEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(RulesDb.Features.Table.Table!, RulesDb.Features.Table.Schema);
    builder.HasKey(x => x.FeatureId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.IsPublished);
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
  }
}
