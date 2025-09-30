using Krakenar.Core;
using Krakenar.Infrastructure;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.PostgreSQL;
using SkillCraft.Cms.Infrastructure.SqlServer;
using SkillCraft.Cms.Seeding.Game.Tasks;
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
    services.AddSkillCraftCmsCore();
    services.AddSkillCraftCmsInfrastructure();
    DatabaseProvider databaseProvider = _configuration.GetValue<DatabaseProvider?>("DatabaseProvider") ?? DatabaseProvider.EntityFrameworkCoreSqlServer;
    switch (databaseProvider)
    {
      case DatabaseProvider.EntityFrameworkCorePostgreSQL:
        services.AddSkillCraftCmsInfrastructurePostgreSQL(_configuration);
        break;
      case DatabaseProvider.EntityFrameworkCoreSqlServer:
        services.AddSkillCraftCmsInfrastructureSqlServer(_configuration);
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
    services.AddTransient<ICommandHandler<SeedSpecializationsTask, SeedingTaskResult>, SeedSpecializationsTaskHandler>();
  }
}
