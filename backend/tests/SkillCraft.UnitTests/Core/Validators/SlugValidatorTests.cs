using FluentValidation;

namespace SkillCraft.Core.Validators;

[Trait(Traits.Category, Categories.Unit)]
public class SlugValidatorTests
{
  private readonly ValidationContext<SlugValidatorTests> _context;
  private readonly SlugValidator<SlugValidatorTests> _validator = new();

  public SlugValidatorTests()
  {
    _context = new(this);
  }

  [Theory(DisplayName = "IsValid: it should return false then the value is not a valid slug.")]
  [InlineData("")]
  [InlineData("   ")]
  [InlineData("hello--world")]
  [InlineData("hello-world-123!")]
  public void Given_InvalidValue_When_IsValid_Then_False(string value)
  {
    Assert.False(_validator.IsValid(_context, value));
  }

  [Theory(DisplayName = "IsValid: it should return true then the value is a valid slug.")]
  [InlineData("hello")]
  [InlineData("hello-world")]
  public void Given_ValidValue_When_IsValid_Then_True(string value)
  {
    Assert.True(_validator.IsValid(_context, value));
  }
}
