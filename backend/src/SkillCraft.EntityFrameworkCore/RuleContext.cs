using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore;

public sealed class RuleContext : DbContext
{
  public const string Schema = "Rules";

  public RuleContext(DbContextOptions<RuleContext> options) : base(options)
  {
  }

  internal DbSet<AttributeEntity> Attributes => Set<AttributeEntity>();
  internal DbSet<CasteEntity> Castes => Set<CasteEntity>();
  internal DbSet<CustomizationEntity> Customizations => Set<CustomizationEntity>();
  internal DbSet<EducationEntity> Educations => Set<EducationEntity>();
  internal DbSet<SkillEntity> Skills => Set<SkillEntity>();
  internal DbSet<StatisticEntity> Statistics => Set<StatisticEntity>();
  internal DbSet<TalentEntity> Talents => Set<TalentEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
