using FluentValidation;
using SkillCraft.Rules.Compiler.Models;

namespace SkillCraft.Rules.Compiler.Validators;

internal class CasteValidator : AbstractValidator<CastePayload>
{
  public CasteValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Skill).NotEmpty();
    RuleFor(x => x.WealthRoll).NotEmpty().Roll();
    RuleFor(x => x.Summary).Summary();
    RuleFor(x => x.Description).Description();
    RuleFor(x => x.FeatureName).Name();
    RuleFor(x => x.FeatureDescription).Description();
  }
}
