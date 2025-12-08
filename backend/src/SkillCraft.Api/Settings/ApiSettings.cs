namespace SkillCraft.Api.Settings;

public record ApiSettings
{
  private const string SectionKey = "Api";

  public bool EnableSwagger { get; set; }
  public string Title { get; set; } = string.Empty;
  public Version Version { get; set; } = new();

  public static ApiSettings Initialize(IConfiguration configuration)
  {
    ApiSettings settings = configuration.GetSection(SectionKey).Get<ApiSettings>() ?? new();

    // TODO(fpion): environment variables

    return settings;
  }
}
