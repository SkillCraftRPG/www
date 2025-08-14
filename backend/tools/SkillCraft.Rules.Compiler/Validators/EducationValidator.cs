using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class EducationValidator : AbstractValidator<EducationPayload>
{
  public EducationValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Skill).NotEmpty();
    RuleFor(x => x.WealthMultiplier).InclusiveBetween(4, 12);
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
    RuleFor(x => x.FeatureName).Name();
    RuleFor(x => x.FeatureDescription).Description();
  }
}
