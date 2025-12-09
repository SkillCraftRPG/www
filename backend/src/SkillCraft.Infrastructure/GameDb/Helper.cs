using SkillCraft.Core;

namespace SkillCraft.Infrastructure.GameDb;

internal static class Helper
{
  public static string Normalize(Slug slug) => Normalize(slug.Value);
  public static string Normalize(string value) => value.Trim().ToLowerInvariant(); // TODO(fpion): better normalization function
}
