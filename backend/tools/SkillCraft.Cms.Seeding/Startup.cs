using Krakenar.Core;
using Krakenar.EntityFrameworkCore.PostgreSQL;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.SqlServer;
using Krakenar.Infrastructure;
using SkillCraft.Cms.Seeding.Krakenar.Tasks;

namespace SkillCraft.Cms.Seeding;

internal class Startup
{
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddKrakenarCore();
    services.AddKrakenarInfrastructure();
    services.AddKrakenarEntityFrameworkCoreRelational();
    DatabaseProvider databaseProvider = _configuration.GetValue<DatabaseProvider?>("DatabaseProvider") ?? DatabaseProvider.EntityFrameworkCoreSqlServer;
    switch (databaseProvider)
    {
      case DatabaseProvider.EntityFrameworkCorePostgreSQL:
        services.AddKrakenarEntityFrameworkCorePostgreSQL(_configuration);
        break;
      case DatabaseProvider.EntityFrameworkCoreSqlServer:
        services.AddKrakenarEntityFrameworkCoreSqlServer(_configuration);
        break;
      default:
        throw new DatabaseProviderNotSupportedException(databaseProvider);
    }
    services.AddSingleton<IApplicationContext, SeedingApplicationContext>();

    services.AddHostedService<CmsSeedingWorker>();
    AddCommandHandlers(services);
  }

  private static void AddCommandHandlers(IServiceCollection services)
  {
    services.AddTransient<ICommandHandler<InitializeConfigurationTask, SeedingTaskResult>, InitializeConfigurationTaskHandler>();
    services.AddTransient<ICommandHandler<MigrateDatabaseTask, SeedingTaskResult>, MigrateDatabaseTaskHandler>();
    services.AddTransient<ICommandHandler<SeedContentTypesTask, SeedingTaskResult>, SeedContentTypesTaskHandler>();
    services.AddTransient<ICommandHandler<SeedFieldTypesTask, SeedingTaskResult>, SeedFieldTypesTaskHandler>();
  }
}
