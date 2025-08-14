using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class AttributeValidator : AbstractValidator<AttributePayload>
{
  public AttributeValidator()
  {
    RuleFor(x => x.Id).NotEmpty();

    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Value).IsInEnum();
    RuleFor(x => x.Category).IsInEnum();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
  }
}
