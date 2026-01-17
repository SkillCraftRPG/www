using Krakenar.Core;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.PostgreSQL;
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
    services.AddSkillCraftCmsInfrastructurePostgreSQL(_configuration);
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
    services.AddTransient<ICommandHandler<ExtractSpecializationsTask, TaskResult>, ExtractSpecializationsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractSpellsTask, TaskResult>, ExtractSpellsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractStatisticsTask, TaskResult>, ExtractStatisticsTaskHandler>();
    services.AddTransient<ICommandHandler<ExtractTalentsTask, TaskResult>, ExtractTalentsTaskHandler>();
  }
}
