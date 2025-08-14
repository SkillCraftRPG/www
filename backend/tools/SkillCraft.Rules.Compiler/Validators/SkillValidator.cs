using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class SkillValidator : AbstractValidator<SkillPayload>
{
  public SkillValidator()
  {
    RuleFor(x => x.Id).NotEmpty();

    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Value).IsInEnum();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
  }
}
