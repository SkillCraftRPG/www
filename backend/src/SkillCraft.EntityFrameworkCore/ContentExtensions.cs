using Krakenar.Core.Contents;
using Krakenar.Core.Fields;

namespace SkillCraft.EntityFrameworkCore;

internal static class ContentExtensions
{
  public static bool GetBooleanValue(this ContentLocale locale, Guid field, bool defaultValue = false)
  {
    return locale.FieldValues.TryGetValue(field, out FieldValue? value) ? bool.Parse(value.Value) : defaultValue;
  }

  public static int GetInt32Value(this ContentLocale locale, Guid field, int defaultValue = 0)
  {
    return locale.FieldValues.TryGetValue(field, out FieldValue? value) ? int.Parse(value.Value) : defaultValue;
  }

  public static string GetStringValue(this ContentLocale locale, Guid field, string defaultValue = "")
  {
    return locale.FieldValues.TryGetValue(field, out FieldValue? value) ? value.Value : defaultValue;
  }
}
