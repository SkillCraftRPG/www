using FluentValidation;

namespace SkillCraft.Core;

[Trait(Traits.Category, Categories.Unit)]
public class DescriptionTests
{
  [Fact(DisplayName = "It should construct the correct instance.")]
  public void Given_Value_When_ctor_Then_Description()
  {
    string value = "  test description  ";
    Description description = new(value);
    Assert.Equal(value.Trim(), description.Value);
  }

  [Fact(DisplayName = "It should throw ValidationException when the value is not valid.")]
  public void Given_InvalidValue_When_ctor_Then_ValidationException()
  {
    var exception = Assert.Throws<ValidationException>(() => new Description("   "));
    Assert.Single(exception.Errors);
    Assert.Contains(exception.Errors, e => e.ErrorCode == "NotEmptyValidator" && e.PropertyName == "Value");
  }

  [Fact(DisplayName = "ToString: it should return the correct string representation.")]
  public void Given_Description_When_ToString_Then_CorrectString()
  {
    string value = "test description";
    Description description = new(value);
    Assert.Equal(value, description.ToString());
  }

  [Fact(DisplayName = "TryCreate: it should create the correct instance.")]
  public void Given_Value_When_TryCreate_Then_Description()
  {
    string value = "  test description  ";
    Description? description = Description.TryCreate(value);
    Assert.NotNull(description);
    Assert.Equal(value.Trim(), description.Value);
  }

  [Theory(DisplayName = "TryCreate: it should return null when the value is null, empty, or only white space.")]
  [InlineData(null)]
  [InlineData("")]
  [InlineData("  ")]
  public void Given_NullOrWhiteSpace_When_TryCreate_Then_NullReturned(string? value)
  {
    Assert.Null(Description.TryCreate(value));
  }
}
