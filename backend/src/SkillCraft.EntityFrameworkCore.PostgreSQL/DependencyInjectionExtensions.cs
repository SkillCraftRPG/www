using Krakenar.Core;
using Krakenar.EntityFrameworkCore.PostgreSQL;
using Krakenar.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.EntityFrameworkCore.PostgreSQL;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCorePostgreSQL(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("POSTGRESQLCONNSTR_SkillCraft", configuration.GetConnectionString("PostgreSQL"));
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException($"The connection string for the database provider '{DatabaseProvider.EntityFrameworkCorePostgreSQL}' could not be found.", nameof(configuration));
    }
    return services.AddSkillCraftEntityFrameworkCorePostgreSQL(connectionString.Trim());
  }
  public static IServiceCollection AddSkillCraftEntityFrameworkCorePostgreSQL(this IServiceCollection services, string connectionString)
  {
    return services
      .AddKrakenarEntityFrameworkCorePostgreSQL(connectionString)
      .AddDbContext<GameContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("SkillCraft.EntityFrameworkCore.PostgreSQL")));
  }
}
