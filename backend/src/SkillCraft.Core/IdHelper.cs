using Logitar;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public static class IdHelper
{
  private const char Separator = '|';
  private const char EntitySeparator = ':';

  public static string Combine(string type, Guid id, WorldId? worldId = null)
  {
    string entity = string.Join(EntitySeparator, type, Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64());
    return worldId.HasValue ? string.Join(Separator, worldId.Value, entity) : entity;
  }

  public static Tuple<string, Guid, WorldId?> Parse(string value)
  {
    string[] values = value.Split(Separator);
    if (values.Length < 1 || values.Length > 2)
    {
      throw new ArgumentException($"The value '{value}' is not a valid identifier.", nameof(value));
    }

    WorldId? worldId = values.Length > 1 ? new(values.First()) : null;

    string[] entity = values.Last().Split(EntitySeparator);
    if (entity.Length != 2)
    {
      throw new ArgumentException($"The value '{values.Last()}' is not a valid entity.", nameof(value));
    }
    string entityType = entity.First();
    Guid entityId = new(Convert.FromBase64String(entity.Last().FromUriSafeBase64()));

    return new Tuple<string, Guid, WorldId?>(entityType, entityId, worldId);
  }
  public static Tuple<Guid, WorldId?> Parse(string value, string expectedType)
  {
    Tuple<string, Guid, WorldId?> parsed = Parse(value);
    if (parsed.Item1 != expectedType)
    {
      throw new ArgumentOutOfRangeException(nameof(value), $"The entity kind '{expectedType}' was expected, but '{parsed.Item1}' was received.");
    }
    return new Tuple<Guid, WorldId?>(parsed.Item2, parsed.Item3);
  }

  public static void Validate(string value, string expectedType)
  {
    Tuple<string, Guid, WorldId?> parsed = Parse(value);
    if (parsed.Item1 != expectedType)
    {
      throw new ArgumentOutOfRangeException(nameof(value), $"The entity kind '{expectedType}' was expected, but '{parsed.Item1}' was received.");
    }
  }
}
