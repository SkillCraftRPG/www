using FluentValidation;

namespace SkillCraft.Core;

[Trait(Traits.Category, Categories.Unit)]
public class SlugTests
{
  [Fact(DisplayName = "It should construct the correct instance.")]
  public void Given_Value_When_ctor_Then_Slug()
  {
    string value = "  test-slug  ";
    Slug slug = new(value);
    Assert.Equal(value.Trim(), slug.Value);
  }

  [Fact(DisplayName = "It should throw ValidationException when the value is not valid.")]
  public void Given_InvalidValue_When_ctor_Then_ValidationException()
  {
    var exception = Assert.Throws<ValidationException>(() => new Slug("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pellentesque tristique sem, vel varius libero ultrices id. Pellentesque ut laoreet ante, eget sagittis enim. Etiam posuere consequat ipsum, eu feugiat justo mollis id. Donec vitae convallis quam. Suspendisse potenti. Pellentesque id."));
    Assert.Equal(2, exception.Errors.Count());
    Assert.Contains(exception.Errors, e => e.ErrorCode == "MaximumLengthValidator" && e.PropertyName == "Value");
    Assert.Contains(exception.Errors, e => e.ErrorCode == "SlugValidator" && e.PropertyName == "Value");
  }

  [Fact(DisplayName = "ToString: it should return the correct string representation.")]
  public void Given_Slug_When_ToString_Then_CorrectString()
  {
    string value = "test-slug";
    Slug slug = new(value);
    Assert.Equal(value, slug.ToString());
  }
}
