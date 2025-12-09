using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Actors;

public static class ActorHelper
{
  private const char Separator = '|';
  private const char EntitySeparator = ':';
  private const string Realm = "Realm";

  public static ActorId GetActorId(Actor actor)
  {
    string? realm = actor.RealmId.HasValue ? Combine(Realm, actor.RealmId.Value) : null;
    string entity = Combine(actor.Type.ToString(), actor.Id);
    return new ActorId(string.IsNullOrWhiteSpace(realm) ? entity : string.Join(Separator, realm, entity));
  }

  public static Actor ToActor(ActorId actorId)
  {
    string[] parts = actorId.Value.Split(Separator);
    if (parts.Length < 1 || parts.Length > 2)
    {
      throw new ArgumentException($"The value '{actorId}' is not a valid actor identifier.", nameof(actorId));
    }

    Actor actor = new();

    if (parts.Length == 2)
    {
      actor.RealmId = Parse(parts.First(), Realm);
    }

    Tuple<string, Guid> parsed = Parse(parts.Last());
    if (!Enum.TryParse(parsed.Item1, out ActorType type) || !Enum.IsDefined(type))
    {
      throw new ArgumentException($"The actor type '{parsed.Item1}' is not valid.", nameof(actorId));
    }
    actor.Type = type;
    actor.Id = parsed.Item2;

    return actor;
  }

  private static string Combine(string type, Guid id) => string.Join(EntitySeparator, type, Encode(id));
  private static Tuple<string, Guid> Parse(string value)
  {
    string[] parts = value.Split(EntitySeparator);
    if (parts.Length != 2)
    {
      throw new ArgumentException($"The value '{value}' is not a valid entity.", nameof(value));
    }
    return new Tuple<string, Guid>(parts.First(), Decode(parts.Last()));
  }
  private static Guid Parse(string value, string expectedType)
  {
    Tuple<string, Guid> parsed = Parse(value);
    if (parsed.Item1 != expectedType)
    {
      throw new ArgumentException($"The type '{expectedType}' was expected, but '{parsed.Item1}' was received.", nameof(value));
    }
    return parsed.Item2;
  }

  private static Guid Decode(string id) => new(Convert.FromBase64String(id.FromUriSafeBase64()));
  private static string Encode(Guid id) => Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64();
}
