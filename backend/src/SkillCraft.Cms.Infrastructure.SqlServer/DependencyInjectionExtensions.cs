using Krakenar.Core;
using Krakenar.EntityFrameworkCore.SqlServer;
using Krakenar.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Cms.Infrastructure.SqlServer;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsInfrastructureSqlServer(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("SQLCONNSTR_Krakenar", configuration.GetConnectionString("SqlServer"));
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException($"The connection string for the database provider '{DatabaseProvider.EntityFrameworkCoreSqlServer}' could not be found.", nameof(configuration));
    }

    return services
      .AddKrakenarEntityFrameworkCoreSqlServer(connectionString)
      .AddDbContext<CmsContext>(options => options.UseSqlServer(connectionString, options => options.MigrationsAssembly("SkillCraft.Cms.Infrastructure.SqlServer")));
  }
}
