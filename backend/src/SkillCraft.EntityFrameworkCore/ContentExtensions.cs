using Krakenar.Core.Contents;
using Krakenar.Core.Fields;
using System.Text.Json;

namespace SkillCraft.EntityFrameworkCore;

internal static class ContentExtensions
{
  public static IReadOnlyCollection<Guid> FindRelatedContentValue(this ContentLocale locale, Guid id)
  {
    return TryGetRelatedContentValue(locale, id) ?? throw new InvalidOperationException($"The field value 'Id={id}' was not found.");
  }
  public static IReadOnlyCollection<Guid> GetRelatedContentValue(this ContentLocale locale, Guid id)
  {
    return TryGetRelatedContentValue(locale, id) ?? [];
  }
  public static IReadOnlyCollection<Guid>? TryGetRelatedContentValue(this ContentLocale locale, Guid id)
  {
    string? json = TryGetFieldValue(locale, id)?.Value;
    return json is null ? null : JsonSerializer.Deserialize<IReadOnlyCollection<Guid>>(json);
  }

  public static string FindStringValue(this ContentLocale locale, Guid id)
  {
    return TryGetStringValue(locale, id) ?? throw new InvalidOperationException($"The field value 'Id={id}' was not found.");
  }
  public static string GetStringValue(this ContentLocale locale, Guid id, string defaultValue = "")
  {
    return TryGetStringValue(locale, id) ?? defaultValue;
  }
  public static string? TryGetStringValue(this ContentLocale locale, Guid id)
  {
    return TryGetFieldValue(locale, id)?.Value;
  }

  private static FieldValue? TryGetFieldValue(this ContentLocale locale, Guid id)
  {
    return locale.FieldValues.TryGetValue(id, out FieldValue? value) ? value : null;
  }
}
