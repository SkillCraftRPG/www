using Logitar;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

[Trait(Traits.Category, Categories.Unit)]
public class IdHelperTests
{
  [Fact(DisplayName = "Combine: it should combine an entity with world ID.")]
  public void Given_WorldId_When_Combine_Then_Combined()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    WorldId worldId = WorldId.NewId();

    string identifier = IdHelper.Combine(type, id, worldId);

    Assert.StartsWith(worldId.Value, identifier);
    Assert.Contains("|Test:", identifier);
    Assert.EndsWith(Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64(), identifier);
  }

  [Fact(DisplayName = "Combine: it should combine an entity without world ID.")]
  public void Given_NoWorldId_When_Combine_Then_Combined()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();

    string identifier = IdHelper.Combine(type, id);

    Assert.StartsWith("Test:", identifier);
    Assert.EndsWith(Convert.ToBase64String(id.ToByteArray()).ToUriSafeBase64(), identifier);
  }

  [Fact(DisplayName = "Parse: it should parse an identifier with world ID.")]
  public void Given_WorldId_When_Parse_Then_Parsed()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    WorldId worldId = WorldId.NewId();
    string identifier = IdHelper.Combine(type, id, worldId);

    Tuple<string, Guid, WorldId?> parsed = IdHelper.Parse(identifier);

    Assert.Equal(type, parsed.Item1);
    Assert.Equal(id, parsed.Item2);
    Assert.NotNull(parsed.Item3);
    Assert.Equal(worldId, parsed.Item3.Value);
  }

  [Fact(DisplayName = "Parse: it should parse an identifier without world ID.")]
  public void Given_NoWorldId_When_Parse_Then_Parsed()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    string identifier = IdHelper.Combine(type, id);

    Tuple<string, Guid, WorldId?> parsed = IdHelper.Parse(identifier);

    Assert.Equal(type, parsed.Item1);
    Assert.Equal(id, parsed.Item2);
    Assert.Null(parsed.Item3);
  }

  [Fact(DisplayName = "Parse: it should parse an identifier with an expected type, but without world ID.")]
  public void Given_ExpectedTypeNoWorldId_When_Parse_Then_Parsed()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    string identifier = IdHelper.Combine(type, id);

    Tuple<Guid, WorldId?> parsed = IdHelper.Parse(identifier, type);

    Assert.Equal(id, parsed.Item1);
    Assert.Null(parsed.Item2);
  }

  [Fact(DisplayName = "Parse: it should parse an identifier with an expected type and world ID.")]
  public void Given_ExpectedTypeWorldId_When_Parse_Then_Parsed()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    WorldId worldId = WorldId.NewId();
    string identifier = IdHelper.Combine(type, id, worldId);

    Tuple<Guid, WorldId?> parsed = IdHelper.Parse(identifier, type);

    Assert.Equal(id, parsed.Item1);
    Assert.NotNull(parsed.Item2);
    Assert.Equal(worldId, parsed.Item2);
  }

  [Fact(DisplayName = "Parse: it should throw ArgumentException when the entity is not valid.")]
  public void Given_InvalidEntity_When_Parse_Then_ArgumentException()
  {
    string value = "invalid-entity";
    var exception = Assert.Throws<ArgumentException>(() => IdHelper.Parse(value));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith($"The value '{value}' is not a valid entity.", exception.Message);
  }

  [Fact(DisplayName = "Parse: it should throw ArgumentException when the value is not valid.")]
  public void Given_InvalidValue_When_Parse_Then_ArgumentException()
  {
    string value = "part1|part2|part3";
    var exception = Assert.Throws<ArgumentException>(() => IdHelper.Parse(value));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith($"The value '{value}' is not a valid identifier.", exception.Message);
  }

  [Fact(DisplayName = "Parse: it should throw ArgumentOutOfRangeException when the type was not expected.")]
  public void Given_UnexpectedType_When_Parse_Then_ArgumentOutOfRangeException()
  {
    string type = "Test";
    string expectedType = "Other";
    Guid id = Guid.NewGuid();
    string identifier = IdHelper.Combine(type, id);

    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => IdHelper.Parse(identifier, expectedType));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith($"The entity kind '{expectedType}' was expected, but '{type}' was received.", exception.Message);
  }

  [Fact(DisplayName = "Validate: it should throw ArgumentOutOfRangeException when the type was not expected.")]
  public void Given_UnexpectedType_When_Validate_Then_ArgumentOutOfRangeException()
  {
    string type = "Test";
    string expectedType = "Other";
    Guid id = Guid.NewGuid();
    string identifier = IdHelper.Combine(type, id);

    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => IdHelper.Validate(identifier, expectedType));
    Assert.Equal("value", exception.ParamName);
    Assert.StartsWith($"The entity kind '{expectedType}' was expected, but '{type}' was received.", exception.Message);
  }

  [Fact(DisplayName = "Validate: it should validate the type.")]
  public void Given_ExpectedType_When_Validate_Then_Success()
  {
    string type = "Test";
    Guid id = Guid.NewGuid();
    string identifier = IdHelper.Combine(type, id);
    IdHelper.Validate(identifier, type);
  }
}
