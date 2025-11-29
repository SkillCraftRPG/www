namespace SkillCraft.Api.Settings;

internal record RefreshTokenCookieSettings
{
  public bool HttpOnly { get; set; }
  public TimeSpan? MaxAge { get; set; }
  public SameSiteMode SameSite { get; set; }
  public bool Secure { get; set; }
}
