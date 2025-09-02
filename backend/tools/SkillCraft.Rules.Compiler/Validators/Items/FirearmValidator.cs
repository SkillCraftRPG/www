using FluentValidation;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class FirearmValidator : AbstractValidator<FirearmPayload>
{
  public FirearmValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Category).IsInEnum();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Weight).GreaterThanOrEqualTo(0);

    When(x => !string.IsNullOrWhiteSpace(x.DamageRoll) || x.DamageType.HasValue, () =>
    {
      When(x => !string.IsNullOrWhiteSpace(x.DamageRoll), () => RuleFor(x => x.DamageRoll!).Roll())
        .Otherwise(() => RuleFor(x => x.DamageRoll).NotEmpty());
      RuleFor(x => x.DamageType).IsInEnum();
    }).Otherwise(() =>
    {
      RuleFor(x => x.DamageRoll).Empty();
      RuleFor(x => x.DamageType).Null();
    });

    When(x => x.AmmunitionStandard.HasValue || x.AmmunitionLong.HasValue, () =>
    {
      RuleFor(x => x.AmmunitionStandard).GreaterThan(0);
      RuleFor(x => x.AmmunitionLong).GreaterThan(x => x.AmmunitionStandard);
    }).Otherwise(() =>
    {
      RuleFor(x => x.AmmunitionStandard).Null();
      RuleFor(x => x.AmmunitionLong).Null();
    });

    RuleFor(x => x.Properties).Must(BeValidFirearmProperties)
      .WithErrorCode("PropertiesValidator")
      .WithMessage("'{PropertyName}' must be a list of firearm properties separated by a comma (,).");
  }

  private static bool BeValidFirearmProperties(string? properties)
  {
    if (string.IsNullOrWhiteSpace(properties))
    {
      return true;
    }

    return properties.Split(',').All(value => Enum.TryParse(value.Trim(), ignoreCase: true, out WeaponProperty property) && Enum.IsDefined(property));
  }
}
