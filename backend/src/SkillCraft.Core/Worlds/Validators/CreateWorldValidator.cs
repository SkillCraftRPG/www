using FluentValidation;
using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds.Validators;

internal class CreateWorldValidator : AbstractValidator<CreateWorldPayload>
{
  public CreateWorldValidator()
  {
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    When(x => !string.IsNullOrWhiteSpace(x.Description), () => RuleFor(x => x.Description!).Description());
  }
}
