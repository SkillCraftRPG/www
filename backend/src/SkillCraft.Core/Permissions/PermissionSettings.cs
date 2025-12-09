using Logitar;
using Microsoft.Extensions.Configuration;

namespace SkillCraft.Core.Permissions;

internal record PermissionSettings
{
  private const string SectionKey = "Permission";

  public int WorldLimit { get; set; }

  public static PermissionSettings Initialize(IConfiguration configuration)
  {
    PermissionSettings settings = configuration.GetSection(SectionKey).Get<PermissionSettings>() ?? new();

    settings.WorldLimit = EnvironmentHelper.GetInt32("PERMISSION_WORLD_LIMIT", settings.WorldLimit);

    return settings;
  }
}
