using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure;
using Krakenar.MongoDB;
using Krakenar.Web;
using Krakenar.Web.Middlewares;
using Krakenar.Web.Settings;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Extensions;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.PostgreSQL;
using SkillCraft.Cms.Infrastructure.SqlServer;

namespace SkillCraft.Cms;

internal class Startup : StartupBase
{
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public override void ConfigureServices(IServiceCollection services)
  {
    base.ConfigureServices(services);

    services.AddApplicationInsightsTelemetry();

    services.AddSkillCraftCmsCore();
    services.AddSkillCraftCmsInfrastructure();
    services.AddKrakenarWeb(_configuration);

    AdminSettings? adminSettings = services.Where(x => x.ServiceType.Equals(typeof(AdminSettings)) && x.ImplementationInstance is AdminSettings)
      .FirstOrDefault()?.ImplementationInstance as AdminSettings
      ?? throw new InvalidOperationException($"The {nameof(AdminSettings)} service has not been regiseterd.");
    if (adminSettings.EnableSwagger)
    {
      services.AddKrakenarSwagger(adminSettings);
    }

    IHealthChecksBuilder healthChecks = services.AddHealthChecks();
    DatabaseProvider databaseProvider = GetDatabaseProvider();
    switch (databaseProvider)
    {
      case DatabaseProvider.EntityFrameworkCorePostgreSQL:
        services.AddSkillCraftCmsInfrastructurePostgreSQL(_configuration);
        healthChecks.AddDbContextCheck<EventContext>();
        healthChecks.AddDbContextCheck<KrakenarContext>();
        break;
      case DatabaseProvider.EntityFrameworkCoreSqlServer:
        services.AddSkillCraftCmsInfrastructureSqlServer(_configuration);
        healthChecks.AddDbContextCheck<EventContext>();
        healthChecks.AddDbContextCheck<KrakenarContext>();
        break;
      default:
        throw new DatabaseProviderNotSupportedException(databaseProvider);
    }
    services.AddKrakenarMongoDB(_configuration);
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

  public override void Configure(IApplicationBuilder builder)
  {
    if (builder is WebApplication application)
    {
      Configure(application);
    }
  }
  public virtual void Configure(WebApplication application)
  {
    AdminSettings adminSettings = application.Services.GetRequiredService<AdminSettings>();
    if (adminSettings.EnableSwagger)
    {
      application.UseKrakenarSwagger(adminSettings);
    }

    application.UseHttpsRedirection();
    application.UseCors();
    application.UseStaticFiles();
    application.UseExceptionHandler();
    application.UseSession();
    application.UseMiddleware<Logging>();
    application.UseMiddleware<RenewSession>();
    application.UseMiddleware<RedirectNotFound>();
    application.UseAuthentication();
    application.UseAuthorization();
    application.UseMiddleware<ResolveRealm>();
    application.UseMiddleware<ResolveUser>();

    application.MapControllers();
    application.MapControllerRoute(name: "Admin", pattern: $"{adminSettings.BasePath}/{{**anything}}", defaults: new { Controller = "Admin", Action = "Index" });
    application.MapHealthChecks("/health");
  }
}
