using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Entities;
using SkillCraft.Infrastructure.GameDb;

namespace SkillCraft.Infrastructure.Configurations;

internal class WorldConfiguration : AggregateConfiguration<WorldEntity>, IEntityTypeConfiguration<WorldEntity>
{
  public override void Configure(EntityTypeBuilder<WorldEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(Worlds.Table.Table!, Worlds.Table.Schema);
    builder.HasKey(x => x.WorldId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.UserId);
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Name).HasMaxLength(Name.MaximumLength);
  }
}
