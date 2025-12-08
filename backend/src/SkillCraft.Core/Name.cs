using FluentValidation;

namespace SkillCraft.Core;

public record Name
{
  public const int MaximumLength = 0; // TODO(fpion): implement

  public string Value { get; }

  public Name(string value)
  {
    Value = value.Trim();
    new Validator().ValidateAndThrow(this);
  }

  public override string ToString() => Value;

  private class Validator : AbstractValidator<Name>
  {
    public Validator()
    {
      RuleFor(x => x.Value).Name();
    }
  }
}
