using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure;

public class RulesContext : DbContext
{
  public const string Schema = "Rules";

  public RulesContext(DbContextOptions<RulesContext> options) : base(options)
  {
  }

  internal DbSet<AttributeEntity> Attributes => Set<AttributeEntity>();
  internal DbSet<SkillEntity> Skills => Set<SkillEntity>();
  internal DbSet<SpecializationEntity> Specializations => Set<SpecializationEntity>();
  internal DbSet<StatisticEntity> Statistics => Set<StatisticEntity>();
  internal DbSet<TalentEntity> Talents => Set<TalentEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
