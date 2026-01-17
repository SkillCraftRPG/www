using Logitar;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor;

internal static class ExtractionMapper
{
  public static AttributeDto ToAttribute(AttributeEntity source)
  {
    AttributeDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Category = source.Category,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    return destination;
  }

  public static CasteDto ToCaste(CasteEntity source)
  {
    CasteDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      WealthRoll = source.WealthRoll,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Skill is not null)
    {
      destination.Skill = ToRelationship(source.Skill);
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.Feature is not null)
    {
      destination.Feature = ToFeature(source.Feature);
    }
    else if (source.FeatureId.HasValue)
    {
      throw new ArgumentException("The feature is required.", nameof(source));
    }

    return destination;
  }

  public static CustomizationDto ToCustomization(CustomizationEntity source)
  {
    CustomizationDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Kind = source.Kind,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    return destination;
  }

  public static EducationDto ToEducation(EducationEntity source)
  {
    EducationDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      WealthMultiplier = source.WealthMultiplier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Skill is not null)
    {
      destination.Skill = ToRelationship(source.Skill);
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.Feature is not null)
    {
      destination.Feature = ToFeature(source.Feature);
    }
    else if (source.FeatureId.HasValue)
    {
      throw new ArgumentException("The feature is required.", nameof(source));
    }

    return destination;
  }

  public static FeatureDto ToFeature(FeatureEntity source)
  {
    FeatureDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Name = source.Name,
      Description = source.Description
    };
    return destination;
  }

  public static RelationshipDto ToRelationship(AttributeEntity attribute) => new(attribute.Slug, attribute.Name, attribute.IsPublished, attribute.Id);
  public static RelationshipDto ToRelationship(SkillEntity skill) => new(skill.Slug, skill.Name, skill.IsPublished, skill.Id);
  public static RelationshipDto ToRelationship(TalentEntity talent) => new(talent.Slug, talent.Name, talent.IsPublished, talent.Id);

  public static SkillDto ToSkill(SkillEntity source)
  {
    SkillDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Attribute is not null)
    {
      destination.Attribute = ToRelationship(source.Attribute);
    }
    else if (source.AttributeId.HasValue)
    {
      throw new ArgumentException("The attribute is required.", nameof(source));
    }

    return destination;
  }

  public static SpecializationDto ToSpecialization(SpecializationEntity source)
  {
    SpecializationDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.MandatoryTalent is not null)
    {
      destination.Requirements.Talent = ToRelationship(source.MandatoryTalent);
    }
    else if (source.MandatoryTalentId.HasValue)
    {
      throw new ArgumentException("The mandatory talent is required.", nameof(source));
    }

    if (source.OtherRequirements is not null)
    {
      destination.Requirements.Other.AddRange(SplitOnNewLine(source.OtherRequirements));
    }

    foreach (SpecializationOptionalTalentEntity optional in source.OptionalTalents)
    {
      if (optional.Talent is null)
      {
        throw new ArgumentException("The optional talent is required.", nameof(source));
      }
      destination.Options.Talents.Add(ToRelationship(optional.Talent));
    }

    if (source.OtherOptions is not null)
    {
      destination.Options.Other.AddRange(SplitOnNewLine(source.OtherOptions));
    }

    if (source.ReservedTalentName is not null)
    {
      destination.ReservedTalent = new ReservedTalentDto(source.ReservedTalentName);

      if (source.ReservedTalentDescription is not null)
      {
        destination.ReservedTalent.Description.AddRange(SplitOnNewLine(source.ReservedTalentDescription));
      }

      foreach (SpecializationDiscountedTalentEntity discounted in source.DiscountedTalents)
      {
        if (discounted.Talent is null)
        {
          throw new ArgumentException("The discounted talent is required.", nameof(source));
        }
        destination.ReservedTalent.DiscountedTalents.Add(ToRelationship(discounted.Talent));
      }

      foreach (SpecializationFeatureEntity granted in source.Features)
      {
        if (granted.Feature is null)
        {
          throw new ArgumentException("The feature is required.", nameof(source));
        }
        destination.ReservedTalent.Features.Add(ToFeature(granted.Feature));
      }
    }

    return destination;
  }

  public static SpellDto ToSpell(SpellEntity source)
  {
    SpellDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    foreach (SpellLevelEntity level in source.Levels)
    {
      destination.Abilities.Add(ToSpellAbility(level));
    }

    return destination;
  }
  public static SpellAbilityDto ToSpellAbility(SpellLevelEntity source)
  {
    SpellAbilityDto destination = new()
    {
      Level = source.Level,
      Name = source.Name,
      Range = source.Range,
      Description = source.Description
    };

    destination.Casting.Time = source.CastingTime;
    destination.Casting.Ritual = source.IsRitual;

    if (source.Duration.HasValue && source.DurationUnit.HasValue)
    {
      destination.Duration = new SpellDurationDto
      {
        Value = source.Duration.Value,
        Unit = source.DurationUnit.Value,
        Concentration = source.IsConcentration
      };
    }

    destination.Components.Focus = source.Focus;
    destination.Components.Material = source.Material;
    destination.Components.Somatic = source.IsSomatic;
    destination.Components.Verbal = source.IsVerbal;

    return destination;
  }

  public static StatisticDto ToStatistic(StatisticEntity source)
  {
    if (source.Attribute is null)
    {
      throw new ArgumentException("The attribute is required.", nameof(source));
    }

    StatisticDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Attribute = ToRelationship(source.Attribute),
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };
    return destination;
  }

  public static TalentDto ToTalent(TalentEntity source)
  {
    TalentDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      AllowMultiplePurchases = source.AllowMultiplePurchases,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Skill is not null)
    {
      destination.Skill = ToRelationship(source.Skill);
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.RequiredTalent is not null)
    {
      destination.RequiredTalent = ToRelationship(source.RequiredTalent);
    }
    else if (source.RequiredTalentId.HasValue)
    {
      throw new ArgumentException("The required talent is required.", nameof(source));
    }

    return destination;
  }

  private static IReadOnlyCollection<string> SplitOnNewLine(string text) => text.Remove("\r").Split('\n')
    .Where(x => !string.IsNullOrWhiteSpace(x))
    .Select(x => x.Trim())
    .ToList().AsReadOnly();
}
