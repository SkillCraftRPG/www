namespace SkillCraft.Rules.Compiler;

internal class Constants
{
  public static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
  public static readonly Encoding Encoding = Encoding.UTF8;
  public static readonly JsonSerializerOptions SerializerOptions = new();

  static Constants()
  {
    SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    SerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    SerializerOptions.WriteIndented = true;
  }
}
