using Krakenar.Core;
using Krakenar.Infrastructure;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.PostgreSQL;
using SkillCraft.Cms.Infrastructure.SqlServer;
using SkillCraft.Rules.Extractor.Tasks;

namespace SkillCraft.Rules.Extractor;

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
    services.AddSingleton<IApplicationContext, ExtractionApplicationContext>();
    services.AddSingleton<IExtractionSerializer, ExtractionSerializer>();

    services.AddHostedService<RuleExtractor>();
    AddCommandHandlers(services);
  }

  private static void AddCommandHandlers(IServiceCollection services)
  {
    services.AddTransient<ICommandHandler<ExtractAttributesTask, TaskResult>, ExtractAttributesTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractCastesTask, TaskResult>, ExtractCastesTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractCustomizationsTask, TaskResult>, ExtractCustomizationsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractEducationsTask, TaskResult>, ExtractEducationsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractSkillsTask, TaskResult>, ExtractSkillsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractStatisticsTask, TaskResult>, ExtractStatisticsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractTalentsTask, TaskResult>, ExtractTalentsTaskHandler>();
  }
}
