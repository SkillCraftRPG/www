using Krakenar.Core.Logging;
using Krakenar.Core.Settings;
using Logitar.EventSourcing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCore(this IServiceCollection services)
  {
    WorldService.Register(services);

    return services
      .AddLogitarEventSourcing()
      .AddSingleton(InitializeRetrySettings)
      .AddScoped<ILoggingService, LoggingService>()
      .AddScoped<IPermissionService, PermissionService>();
  }

  private static RetrySettings InitializeRetrySettings(this IServiceProvider serviceProvider)
  {
    return RetrySettings.Initialize(serviceProvider.GetRequiredService<IConfiguration>());
  }
}
