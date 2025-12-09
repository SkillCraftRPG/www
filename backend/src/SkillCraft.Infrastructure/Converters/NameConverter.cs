using SkillCraft.Core;

namespace SkillCraft.Infrastructure.Converters;

internal class NameConverter : JsonConverter<Name>
{
  public override Name? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    string? value = reader.GetString();
    return string.IsNullOrWhiteSpace(value) ? null : new Name(value);
  }

  public override void Write(Utf8JsonWriter writer, Name name, JsonSerializerOptions options)
  {
    writer.WriteStringValue(name.Value);
  }
}
