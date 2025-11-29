namespace SkillCraft.Settings;

internal record SessionCookieSettings
{
  public SameSiteMode SameSite { get; set; }
}
