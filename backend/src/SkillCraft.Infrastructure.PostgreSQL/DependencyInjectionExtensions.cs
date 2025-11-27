using Logitar.EventSourcing.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Infrastructure.PostgreSQL;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_SkillCraft");
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      connectionString = configuration.GetConnectionString("PostgreSQL");
    }
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException("The connection string for the database provider 'PostgreSQL' could not be found.", nameof(configuration));
    }
    return services.AddSkillCraftInfrastructurePostgreSQL(connectionString);
  }
  public static IServiceCollection AddSkillCraftInfrastructurePostgreSQL(this IServiceCollection services, string connectionString)
  {
    return services
      .AddDbContext<GameContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("SkillCraft.Infrastructure.PostgreSQL")))
      .AddLogitarEventSourcingWithEntityFrameworkCorePostgreSQL(connectionString);
  }
}
