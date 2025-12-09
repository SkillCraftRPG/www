using Logitar;
using Microsoft.Extensions.Configuration;

namespace SkillCraft.Infrastructure.Caching;

internal record CachingSettings
{
  private const string SectionKey = "Caching";

  public TimeSpan ActorLifetime { get; set; }

  public static CachingSettings Initialize(IConfiguration configuration)
  {
    CachingSettings settings = configuration.GetSection(SectionKey).Get<CachingSettings>() ?? new();

    settings.ActorLifetime = EnvironmentHelper.GetTimeSpan("CACHING_ACTOR_LIFETIME", settings.ActorLifetime);

    return settings;
  }
}
