using Microsoft.Extensions.Configuration;

namespace SkillCraft.Core.Permissions;

internal record PermissionSettings
{
  private const string SectionKey = "Permission";

  public int WorldLimit { get; set; }

  public static PermissionSettings Initialize(IConfiguration configuration)
  {
    PermissionSettings settings = configuration.GetSection(SectionKey).Get<PermissionSettings>() ?? new();

    string? worldLimitValue = Environment.GetEnvironmentVariable("PERMISSION_WORLD_LIMIT");
    if (!string.IsNullOrWhiteSpace(worldLimitValue) && int.TryParse(worldLimitValue, out int worldLimit))
    {
      settings.WorldLimit = worldLimit;
    }

    return settings;
  }
}
