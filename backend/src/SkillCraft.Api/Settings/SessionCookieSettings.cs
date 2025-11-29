namespace SkillCraft.Api.Settings;

internal record SessionCookieSettings
{
  public SameSiteMode SameSite { get; set; }
}
