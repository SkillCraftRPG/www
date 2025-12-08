namespace SkillCraft.Infrastructure.GameDb;

internal static class Helper
{
  public static string Normalize(string value) => value.Trim().ToLowerInvariant(); // TODO(fpion): better normalization function
}
