using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Actors;

[Trait(Traits.Category, Categories.Unit)]
public class ActorHelperTests
{
  [Fact(DisplayName = "GetActorId: it should return the correct actor ID with realm.")]
  public void Given_RealmId_When_GetActorId_Then_CorrectActorId()
  {
    Actor actor = new()
    {
      RealmId = Guid.NewGuid(),
      Type = ActorType.User,
      Id = Guid.NewGuid()
    };

    ActorId actorId = ActorHelper.GetActorId(actor);

    Assert.StartsWith("Realm:", actorId.Value);
    Assert.Contains(Convert.ToBase64String(actor.RealmId.Value.ToByteArray()).ToUriSafeBase64(), actorId.Value);
    Assert.Contains("|User:", actorId.Value);
    Assert.EndsWith(Convert.ToBase64String(actor.Id.ToByteArray()).ToUriSafeBase64(), actorId.Value);
  }

  [Fact(DisplayName = "GetActorId: it should return the correct actor ID without realm.")]
  public void Given_NoRealmId_When_GetActorId_Then_CorrectActorId()
  {
    Actor actor = new()
    {
      Type = ActorType.User,
      Id = Guid.NewGuid()
    };

    ActorId actorId = ActorHelper.GetActorId(actor);

    Assert.Contains("User:", actorId.Value);
    Assert.EndsWith(Convert.ToBase64String(actor.Id.ToByteArray()).ToUriSafeBase64(), actorId.Value);
  }

  [Fact(DisplayName = "ToActor: it should return an actor with a realm ID.")]
  public void Given_RealmId_When_ToActor_Then_ActorWithRealmId()
  {
    Guid realmId = Guid.NewGuid();
    ActorType type = ActorType.User;
    Guid id = Guid.NewGuid();
    ActorId actorId = new($"Realm:{Convert.ToBase64String(realmId.ToByteArray()).ToUriSafeBase64()}|{type}:{Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64()}");

    Actor actor = ActorHelper.ToActor(actorId);

    Assert.Equal(realmId, actor.RealmId);
    Assert.Equal(type, actor.Type);
    Assert.Equal(id, actor.Id);
  }

  [Fact(DisplayName = "ToActor: it should return an actor without a realm ID.")]
  public void Given_NoRealmId_When_ToActor_Then_ActorWithoutRealmId()
  {
    ActorType type = ActorType.User;
    Guid id = Guid.NewGuid();
    ActorId actorId = new($"{type}:{Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64()}");

    Actor actor = ActorHelper.ToActor(actorId);

    Assert.Null(actor.RealmId);
    Assert.Equal(type, actor.Type);
    Assert.Equal(id, actor.Id);
  }

  [Fact(DisplayName = "ToActor: it should throw ArgumentException when the actor type is not valid.")]
  public void Given_InvalidActorType_When_ToActor_Then_ArgumentException()
  {
    ActorId actorId = new($"Invalid:{Convert.ToBase64String(Guid.NewGuid().ToByteArray()).ToUriSafeBase64()}");
    var exception = Assert.Throws<ArgumentException>(() => ActorHelper.ToActor(actorId));
    Assert.Equal("actorId", exception.ParamName);
    Assert.StartsWith("The actor type 'Invalid' is not valid.", exception.Message);
  }

  [Fact(DisplayName = "ToActor: it should throw ArgumentException when the entity is not valid.")]
  public void Given_InvalidEntity_When_ToActor_Then_ArgumentException()
  {
    ActorId actorId = new("invalid-entity");
    var exception = Assert.Throws<ArgumentException>(() => ActorHelper.ToActor(actorId));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith($"The value '{actorId}' is not a valid entity.", exception.Message);
  }

  [Fact(DisplayName = "ToActor: it should throw ArgumentException when the identifier is not valid.")]
  public void Given_InvalidIdentifier_When_ToActor_Then_ArgumentException()
  {
    ActorId actorId = new("invalid|actor|id");
    var exception = Assert.Throws<ArgumentException>(() => ActorHelper.ToActor(actorId));
    Assert.Equal("actorId", exception.ParamName);
    Assert.StartsWith($"The value '{actorId}' is not a valid actor identifier.", exception.Message);
  }

  [Fact(DisplayName = "ToActor: it should throw ArgumentException when the realm does not have a valid type.")]
  public void Given_UnexpectedRealmType_When_ToActor_Then_ArgumentException()
  {
    ActorId actorId = new($"{WorldId.NewId()}|User:{Convert.ToBase64String(Guid.NewGuid().ToByteArray()).ToUriSafeBase64()}");
    var exception = Assert.Throws<ArgumentException>(() => ActorHelper.ToActor(actorId));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith("The type 'Realm' was expected, but 'World' was received.", exception.Message);
  }

  [Fact(DisplayName = "ToActor: it should throw ArgumentException when the realm is not valid.")]
  public void Given_InvalidRealm_When_ToActor_Then_ArgumentException()
  {
    ActorId actorId = new($"invalid-realm|User:{Convert.ToBase64String(Guid.NewGuid().ToByteArray()).ToUriSafeBase64()}");
    var exception = Assert.Throws<ArgumentException>(() => ActorHelper.ToActor(actorId));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith("The value 'invalid-realm' is not a valid entity.", exception.Message);
  }
}
