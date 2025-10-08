namespace SkillCraft.Rules.Extractor;

public interface IExtractionSerializer
{
  T? Deserialize<T>(string json);
  string Serialize<T>(T value);
}

internal class ExtractionSerializer : IExtractionSerializer
{
  private readonly JsonSerializerOptions _serializerOptions = new();

  public ExtractionSerializer()
  {
    _serializerOptions.Converters.Add(new JsonStringEnumConverter());
    _serializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    _serializerOptions.WriteIndented = true;
  }

  public T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, _serializerOptions);
  public string Serialize<T>(T value) => JsonSerializer.Serialize(value, _serializerOptions);
}
