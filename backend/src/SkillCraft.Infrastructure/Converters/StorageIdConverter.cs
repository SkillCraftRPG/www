using SkillCraft.Core.Storages;

namespace SkillCraft.Infrastructure.Converters;

internal class StorageIdConverter : JsonConverter<StorageId>
{
  public override StorageId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    string? value = reader.GetString();
    return string.IsNullOrWhiteSpace(value) ? new StorageId() : new(value);
  }

  public override void Write(Utf8JsonWriter writer, StorageId storageId, JsonSerializerOptions options)
  {
    writer.WriteStringValue(storageId.Value);
  }
}
