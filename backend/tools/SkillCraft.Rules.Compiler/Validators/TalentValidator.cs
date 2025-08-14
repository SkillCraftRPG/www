using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class TalentValidator : AbstractValidator<TalentPayload>
{
  public TalentValidator()
  {
    RuleFor(x => x.Id).NotEmpty();

    RuleFor(x => x.Tier).InclusiveBetween(0, 3);

    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
  }
}
