namespace SkillCraft.Api.Settings;

internal record AccessTokenSettings
{
  public string Type { get; set; } = string.Empty;
  public int LifetimeSeconds { get; set; }
}
