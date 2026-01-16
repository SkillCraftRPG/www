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
  internal DbSet<CasteEntity> Castes => Set<CasteEntity>();
  internal DbSet<CustomizationEntity> Customizations => Set<CustomizationEntity>();
  internal DbSet<EducationEntity> Educations => Set<EducationEntity>();
  internal DbSet<FeatureEntity> Features => Set<FeatureEntity>();
  internal DbSet<LanguageEntity> Languages => Set<LanguageEntity>();
  internal DbSet<LineageEntity> Lineages => Set<LineageEntity>();
  internal DbSet<LineageFeatureEntity> LineageFeatures => Set<LineageFeatureEntity>();
  internal DbSet<LineageLanguageEntity> LineageLanguages => Set<LineageLanguageEntity>();
  internal DbSet<ScriptEntity> Scripts => Set<ScriptEntity>();
  internal DbSet<SkillEntity> Skills => Set<SkillEntity>();
  internal DbSet<SpecializationDiscountedTalentEntity> SpecializationDiscountedTalents => Set<SpecializationDiscountedTalentEntity>();
  internal DbSet<SpecializationEntity> Specializations => Set<SpecializationEntity>();
  internal DbSet<SpecializationFeatureEntity> SpecializationFeatures => Set<SpecializationFeatureEntity>();
  internal DbSet<SpecializationOptionalTalentEntity> SpecializationOptionalTalents => Set<SpecializationOptionalTalentEntity>();
  internal DbSet<SpellEntity> Spells => Set<SpellEntity>();
  internal DbSet<StatisticEntity> Statistics => Set<StatisticEntity>();
  internal DbSet<TalentEntity> Talents => Set<TalentEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
