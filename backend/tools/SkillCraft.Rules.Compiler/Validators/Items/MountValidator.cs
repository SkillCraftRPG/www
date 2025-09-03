using FluentValidation;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class MountValidator : AbstractValidator<MountPayload>
{
  public MountValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Vigor).GreaterThan(0);
    RuleFor(x => x.Size).IsInEnum();
    RuleFor(x => x.Load).GreaterThan(0);
  }
}
