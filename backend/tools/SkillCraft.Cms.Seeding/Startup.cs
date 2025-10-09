using Krakenar.Core;
using Krakenar.Infrastructure;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.PostgreSQL;
using SkillCraft.Cms.Infrastructure.SqlServer;
using SkillCraft.Cms.Seeding.Krakenar.Tasks;
using SkillCraft.Cms.Seeding.Rules;
using SkillCraft.Cms.Seeding.Rules.Tasks;
using SkillCraft.Cms.Seeding.Settings;

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
    services.AddSingleton(DefaultSettings.Initialize(_configuration));

    services.AddSkillCraftCmsCore();
    services.AddSkillCraftCmsInfrastructure();
    DatabaseProvider databaseProvider = GetDatabaseProvider();
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

    services.AddHostedService<SeedingWorker>();
    services.AddScoped<IFeatureService, FeatureService>();
    AddCommandHandlers(services);
  }
  private DatabaseProvider GetDatabaseProvider()
  {
    string? value = Environment.GetEnvironmentVariable("DATABASE_PROVIDER");
    if (!string.IsNullOrWhiteSpace(value) && Enum.TryParse(value.Trim(), ignoreCase: true, out DatabaseProvider provider))
    {
      return provider;
    }
    return _configuration.GetValue<DatabaseProvider?>("DatabaseProvider") ?? DatabaseProvider.EntityFrameworkCorePostgreSQL;
  }

  private static void AddCommandHandlers(IServiceCollection services)
  {
    services.AddTransient<ICommandHandler<InitializeConfigurationTask, TaskResult>, InitializeConfigurationTaskHandler>();
    services.AddTransient<ICommandHandler<MigrateDatabaseTask, TaskResult>, MigrateDatabaseTaskHandler>();
    services.AddTransient<ICommandHandler<SeedAttributesTask, TaskResult>, SeedAttributesTaskHandler>();
    services.AddTransient<ICommandHandler<SeedCastesTask, TaskResult>, SeedCastesTaskHandler>();
    services.AddTransient<ICommandHandler<SeedContentTypesTask, TaskResult>, SeedContentTypesTaskHandler>();
    services.AddTransient<ICommandHandler<SeedCustomizationsTask, TaskResult>, SeedCustomizationsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedEducationsTask, TaskResult>, SeedEducationsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedFieldTypesTask, TaskResult>, SeedFieldTypesTaskHandler>();
    services.AddTransient<ICommandHandler<SeedSkillsTask, TaskResult>, SeedSkillsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedSpecializationsTask, TaskResult>, SeedSpecializationsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedStatisticsTask, TaskResult>, SeedStatisticsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedTalentsTask, TaskResult>, SeedTalentsTaskHandler>();
    services.AddTransient<ICommandHandler<SeedUsersTask, TaskResult>, SeedUsersTaskHandler>();
  }
}
