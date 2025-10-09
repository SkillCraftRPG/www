using Krakenar.Core.Caching;
using Krakenar.Core.Configurations;

namespace SkillCraft.Cms;

internal class Program
{
  public static async Task Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    IConfiguration configuration = builder.Configuration;

    Startup startup = new(configuration);
    startup.ConfigureServices(builder.Services);

    WebApplication application = builder.Build();

    startup.Configure(application);
    await LoadConfigurationAsync(application);

    application.Run();
  }
  private static async Task LoadConfigurationAsync(WebApplication application, CancellationToken cancellationToken = default)
  {
    using IServiceScope scope = application.Services.CreateScope();

    ICacheService cacheService = scope.ServiceProvider.GetRequiredService<ICacheService>();
    IConfigurationQuerier configurationQuerier = scope.ServiceProvider.GetRequiredService<IConfigurationQuerier>();
    IConfigurationRepository configurationRepository = scope.ServiceProvider.GetRequiredService<IConfigurationRepository>();

    Configuration configuration = await configurationRepository.LoadAsync(cancellationToken)
      ?? throw new InvalidOperationException("The configuration has not been initialized");
    cacheService.Configuration = await configurationQuerier.ReadAsync(configuration, cancellationToken);
  }
}
