using SkillCraft.Api.Extensions;
using SkillCraft.Api.Settings;

namespace SkillCraft.Api;

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

    services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    CorsSettings corsSettings = CorsSettings.Initialize(_configuration);
    services.AddSingleton(corsSettings);
    services.AddCors();

    ApiSettings apiSettings = ApiSettings.Initialize(_configuration);
    services.AddSingleton(apiSettings);
    if (apiSettings.EnableSwagger)
    {
      services.AddSkillCraftSwagger(apiSettings);
    }

    services.AddApplicationInsightsTelemetry();
    services.AddHealthChecks()/*.AddDbContextCheck<RulesContext>()*/; // TODO(fpion): implement
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
    ApiSettings apiSettings = application.Services.GetRequiredService<ApiSettings>();
    if (apiSettings.EnableSwagger)
    {
      application.UseSkillCraftSwagger(apiSettings);
    }

    application.UseHttpsRedirection();
    application.UseCors();
    //application.UseExceptionHandler(); // TODO(fpion): implement
    application.UseAuthentication();
    application.UseAuthorization();

    application.MapControllers();
    application.MapHealthChecks("/health");
  }
}
