using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class CustomizationValidator : AbstractValidator<CustomizationPayload>
{
  public CustomizationValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Kind).IsInEnum();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
  }
}
