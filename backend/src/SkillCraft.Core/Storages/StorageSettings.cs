using Microsoft.Extensions.Configuration;

namespace SkillCraft.Core.Storages;

internal record StorageSettings
{
  private const string SectionKey = "Storage";

  public long AllocatedBytes { get; set; }

  public static StorageSettings Initialize(IConfiguration configuration)
  {
    StorageSettings settings = configuration.GetSection(SectionKey).Get<StorageSettings>() ?? new();

    string? allocatedBytesValue = Environment.GetEnvironmentVariable("STORAGE_ALLOCATED_BYTES");
    if (!string.IsNullOrWhiteSpace(allocatedBytesValue) && long.TryParse(allocatedBytesValue, out long allocatedBytes))
    {
      settings.AllocatedBytes = allocatedBytes;
    }

    return settings;
  }
}
