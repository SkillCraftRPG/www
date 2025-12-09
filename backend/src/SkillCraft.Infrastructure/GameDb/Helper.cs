using SkillCraft.Core;

namespace SkillCraft.Infrastructure.GameDb;

internal static class Helper
{
  public static string Normalize(Slug slug) => Normalize(slug.Value);
  public static string Normalize(string value)
  {
    if (string.IsNullOrEmpty(value))
    {
      return string.Empty;
    }

    value = value.Trim();
    value = value.Normalize(NormalizationForm.FormKC);
    value = value.ToLowerInvariant();

    StringBuilder builder = new();
    foreach (char c in value.Normalize(NormalizationForm.FormD))
    {
      UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
      if (category != UnicodeCategory.NonSpacingMark)
      {
        builder.Append(c);
      }
    }
    value = builder.ToString().Normalize(NormalizationForm.FormC);

    while (value.Contains("  "))
    {
      value = value.Replace("  ", " ");
    }

    return value;
  }
}
