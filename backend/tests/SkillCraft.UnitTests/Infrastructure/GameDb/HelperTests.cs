namespace SkillCraft.Infrastructure.GameDb;

[Trait(Traits.Category, Categories.Unit)]
public class HelperTests
{
  [Theory(DisplayName = "Normalize: it should normalize a value.")]
  [InlineData(" Sk!llCrâft①   ", "sk!llcraft1")]
  [InlineData("%umai%", "%umai%")]
  public void Given_Value_When_NormalizeKeyword_Then_Normalized(string value, string expected)
  {
    Assert.Equal(expected, Helper.Normalize(value));
  }

  [Theory(DisplayName = "Normalize: it should normalize an empty value.")]
  [InlineData("")]
  [InlineData("    ")]
  public void Given_EmptyValue_When_NormalizeKeyword_Then_Normalized(string value)
  {
    Assert.Equal(string.Empty, Helper.Normalize(value));
  }
}
