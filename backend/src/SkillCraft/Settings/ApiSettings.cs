namespace SkillCraft.Settings;

internal class ApiSettings
{
  private const string SectionKey = "Api";

  public bool EnableSwagger { get; set; }
  public string Title { get; set; } = string.Empty;
  public Version Version { get; set; } = new();

  public static ApiSettings Initialize(IConfiguration configuration)
  {
    ApiSettings settings = configuration.GetSection(SectionKey).Get<ApiSettings>() ?? new();

    string? enableSwaggerValue = Environment.GetEnvironmentVariable("API_ENABLE_SWAGGER");
    if (!string.IsNullOrWhiteSpace(enableSwaggerValue) && bool.TryParse(enableSwaggerValue, out bool enableSwagger))
    {
      settings.EnableSwagger = enableSwagger;
    }

    string? title = Environment.GetEnvironmentVariable("API_TITLE");
    if (!string.IsNullOrWhiteSpace(title))
    {
      settings.Title = title;
    }

    string? versionValue = Environment.GetEnvironmentVariable("API_VERSION");
    if (!string.IsNullOrWhiteSpace(versionValue) && Version.TryParse(versionValue, out Version? version))
    {
      settings.Version = version;
    }

    return settings;
  }
}
