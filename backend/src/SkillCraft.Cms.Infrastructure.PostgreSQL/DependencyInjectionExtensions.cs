using Krakenar.Core;
using Krakenar.EntityFrameworkCore.PostgreSQL;
using Krakenar.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Cms.Infrastructure.PostgreSQL;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsInfrastructurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("POSTGRESQLCONNSTR_Krakenar", configuration.GetConnectionString("PostgreSQL"));
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException($"The connection string for the database provider '{DatabaseProvider.EntityFrameworkCorePostgreSQL}' could not be found.", nameof(configuration));
    }

    return services
      .AddKrakenarEntityFrameworkCorePostgreSQL(connectionString)
      .AddDbContext<RulesContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("SkillCraft.Cms.Infrastructure.PostgreSQL")));
  }
}
