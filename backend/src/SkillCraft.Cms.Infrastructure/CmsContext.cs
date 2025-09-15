using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure;

public class CmsContext : DbContext
{
  public const string Schema = "Cms"; // TODO(fpion): do we want separate DBs? A schema?

  public CmsContext(DbContextOptions<CmsContext> options) : base(options)
  {
  }

  internal DbSet<TalentEntity> Talents => Set<TalentEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
