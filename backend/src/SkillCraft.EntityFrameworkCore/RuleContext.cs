using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore;

public sealed class RuleContext : DbContext
{
  public RuleContext(DbContextOptions<RuleContext> options) : base(options)
  {
  }

  internal DbSet<TalentEntity> Talents => Set<TalentEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
