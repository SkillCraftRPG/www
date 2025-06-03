using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore;

public sealed class GameContext : DbContext
{
  public GameContext(DbContextOptions<GameContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
