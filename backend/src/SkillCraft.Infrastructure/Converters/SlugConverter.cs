using SkillCraft.Core;

namespace SkillCraft.Infrastructure.Converters;

internal class SlugConverter : JsonConverter<Slug>
{
  public override Slug? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    string? value = reader.GetString();
    return string.IsNullOrWhiteSpace(value) ? null : new Slug(value);
  }

  public override void Write(Utf8JsonWriter writer, Slug slug, JsonSerializerOptions options)
  {
    writer.WriteStringValue(slug.Value);
  }
}
