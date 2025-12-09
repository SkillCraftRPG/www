using FluentValidation;

namespace SkillCraft.Core;

[Trait(Traits.Category, Categories.Unit)]
public class NameTests
{
  [Fact(DisplayName = "It should construct the correct instance.")]
  public void Given_Value_When_ctor_Then_Name()
  {
    string value = "  test name  ";
    Name name = new(value);
    Assert.Equal(value.Trim(), name.Value);
  }

  [Theory(DisplayName = "It should throw ValidationException when the value is not valid.")]
  [InlineData("   ", "NotEmptyValidator")]
  [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pellentesque tristique sem, vel varius libero ultrices id. Pellentesque ut laoreet ante, eget sagittis enim. Etiam posuere consequat ipsum, eu feugiat justo mollis id. Donec vitae convallis quam. Suspendisse potenti. Pellentesque id.", "MaximumLengthValidator")]
  public void Given_InvalidValue_When_ctor_Then_ValidationException(string value, string errorCode)
  {
    var exception = Assert.Throws<ValidationException>(() => new Name(value));
    Assert.Single(exception.Errors);
    Assert.Contains(exception.Errors, e => e.ErrorCode == errorCode && e.PropertyName == "Value");
  }

  [Fact(DisplayName = "ToString: it should return the correct string representation.")]
  public void Given_Name_When_ToString_Then_CorrectString()
  {
    string value = "test name";
    Name name = new(value);
    Assert.Equal(value, name.ToString());
  }
}
