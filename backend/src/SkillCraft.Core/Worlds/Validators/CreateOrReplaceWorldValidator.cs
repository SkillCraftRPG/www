using FluentValidation;
using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds.Validators;

internal class CreateOrReplaceWorldValidator : AbstractValidator<CreateOrReplaceWorldPayload>
{
  public CreateOrReplaceWorldValidator()
  {
    _ = RuleFor(x => x.Name).Name();
    _ = When(x => !string.IsNullOrWhiteSpace(x.Description), () => RuleFor(x => x.Description!).Description());
  }
}
