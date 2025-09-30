using FluentValidation;
using Krakenar.Core;
using SkillCraft.Cms.Seeding.Game.Models;

namespace SkillCraft.Cms.Seeding.Game.Validators;

internal class SpecializationValidator : AbstractValidator<SpecializationPayload>
{
  public SpecializationValidator()
  {
    RuleFor(x => x.Id).NotEmpty();

    RuleFor(x => x.Tier).InclusiveBetween(1, 3);
    RuleFor(x => x.Name).DisplayName();

    RuleFor(x => x.Summary).MaximumLength(160);

    RuleFor(x => x.Requirements).SetValidator(new SpecializationRequirementsValidator());
    RuleFor(x => x.Options).SetValidator(new SpecializationOptionsValidator());

    RuleFor(x => x.ReservedTalent).SetValidator(new ReservedTalentValidator());
  }
}

internal class SpecializationRequirementsValidator : AbstractValidator<SpecializationRequirements>
{
  public SpecializationRequirementsValidator()
  {
  }
}

internal class SpecializationOptionsValidator : AbstractValidator<SpecializationOptions>
{
  public SpecializationOptionsValidator()
  {
  }
}

internal class ReservedTalentValidator : AbstractValidator<ReservedTalent>
{
  public ReservedTalentValidator()
  {
    RuleFor(x => x.Name).DisplayName();

    RuleForEach(x => x.Features).SetValidator(new SpecializationFeatureValidator());
  }
}

internal class SpecializationFeatureValidator : AbstractValidator<SpecializationFeature>
{
  public SpecializationFeatureValidator()
  {
    RuleFor(x => x.Name).DisplayName();
  }
}
