using Microsoft.Extensions.Configuration;

namespace SkillCraft.Core.Permissions;

internal record PermissionSettings
{
  private const string SectionKey = "Permission";

  public int WorldLimit { get; set; }

  public static PermissionSettings Initialize(IConfiguration configuration)
  {
    PermissionSettings settings = configuration.GetSection(SectionKey).Get<PermissionSettings>() ?? new();
    // TODO(fpion): Environment Variable Override
    return settings;
  }
}
