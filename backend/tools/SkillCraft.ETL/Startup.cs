using Krakenar.Core;
using Krakenar.Infrastructure;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.PostgreSQL;
using SkillCraft.Infrastructure;

namespace SkillCraft.ETL;

internal class Startup
{
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public void ConfigureService(IServiceCollection services)
  {
    services.AddHostedService<EtlWorker>();

    services.AddSkillCraftCore();
    services.AddSkillCraftInfrastructure();
    services.AddSkillCraftEntityFrameworkCore();
    DatabaseProvider databaseProvider = _configuration.GetValue<DatabaseProvider?>("DatabaseProvider") ?? DatabaseProvider.EntityFrameworkCorePostgreSQL;
    switch (databaseProvider)
    {
      case DatabaseProvider.EntityFrameworkCorePostgreSQL:
        services.AddSkillCraftEntityFrameworkCorePostgreSQL(_configuration);
        break;
      default:
        throw new DatabaseProviderNotSupportedException(databaseProvider);
    }
    services.AddSingleton<IApplicationContext, EtlApplicationContext>();
  }
}
