using Krakenar.Contracts;
using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Cms.Core.Castes.Models;
using SkillCraft.Cms.Core.Customizations.Models;
using SkillCraft.Cms.Core.Educations.Models;
using SkillCraft.Cms.Core.Features.Models;
using SkillCraft.Cms.Core.Languages.Models;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Cms.Core.Scripts.Models;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Core.Specializations.Models;
using SkillCraft.Cms.Core.Spells.Models;
using SkillCraft.Cms.Core.Statistics.Models;
using SkillCraft.Cms.Core.Talents.Models;
using SkillCraft.Cms.Infrastructure.Entities;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure;

internal class RulesMapper
{
  private readonly Dictionary<ActorId, Actor> _actors = [];
  private readonly Actor _system = new();

  public RulesMapper()
  {
  }

  public RulesMapper(IReadOnlyDictionary<ActorId, Actor> actors)
  {
    foreach (KeyValuePair<ActorId, Actor> actor in actors)
    {
      _actors[actor.Key] = actor.Value;
    }
  }

  public AttributeModel ToAttribute(AttributeEntity source)
  {
    AttributeModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Category = source.Category,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    foreach (StatisticEntity statistic in source.Statistics)
    {
      if (statistic.IsPublished)
      {
        destination.Statistics.Add(ToStatistic(statistic, destination));
      }
    }
    foreach (SkillEntity skill in source.Skills)
    {
      if (skill.IsPublished)
      {
        destination.Skills.Add(ToSkill(skill, destination));
      }
    }

    MapAggregate(source, destination);

    return destination;
  }

  public CasteModel ToCaste(CasteEntity source)
  {
    CasteModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      WealthRoll = source.WealthRoll,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Skill is not null)
    {
      if (source.Skill.IsPublished)
      {
        destination.Skill = ToSkill(source.Skill);
      }
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.Feature is not null)
    {
      if (source.Feature.IsPublished)
      {
        destination.Feature = ToFeature(source.Feature);
      }
    }
    else if (source.FeatureId.HasValue)
    {
      throw new ArgumentException("The feature is required.", nameof(source));
    }

    MapAggregate(source, destination);

    return destination;
  }

  public CustomizationModel ToCustomization(CustomizationEntity source)
  {
    CustomizationModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Kind = source.Kind,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    MapAggregate(source, destination);

    return destination;
  }

  public EducationModel ToEducation(EducationEntity source)
  {
    EducationModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      WealthMultiplier = source.WealthMultiplier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Skill is not null)
    {
      if (source.Skill.IsPublished)
      {
        destination.Skill = ToSkill(source.Skill);
      }
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.Feature is not null)
    {
      if (source.Feature.IsPublished)
      {
        destination.Feature = ToFeature(source.Feature);
      }
    }
    else if (source.FeatureId.HasValue)
    {
      throw new ArgumentException("The feature is required.", nameof(source));
    }

    MapAggregate(source, destination);

    return destination;
  }

  public static FeatureModel ToFeature(FeatureEntity source) => new(source.Name, source.Description);

  public LanguageModel ToLanguage(LanguageEntity source)
  {
    LanguageModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      TypicalSpeakers = source.TypicalSpeakers,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Script is not null)
    {
      if (source.Script.IsPublished)
      {
        destination.Script = ToScript(source.Script);
      }
    }
    else if (source.ScriptId.HasValue)
    {
      throw new ArgumentException("The script is required.", nameof(source));
    }

    MapAggregate(source, destination);

    return destination;
  }

  public LineageModel ToLineage(LineageEntity source)
  {
    LineageModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Names = source.GetNames(),
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description,
      Speeds = source.GetSpeeds(),
      Size = source.GetSize(),
      Weight = source.GetWeight(),
      Age = source.GetAge()
    };

    if (source.Parent is not null && source.Parent.IsPublished)
    {
      destination.Parent = ToLineage(source.Parent);
    }

    foreach (LineageFeatureEntity lineageFeature in source.Features)
    {
      FeatureEntity feature = lineageFeature.Feature
        ?? throw new ArgumentException($"The feature is required (LineageId={lineageFeature.LineageId}, FeatureId={lineageFeature.FeatureId}).", nameof(source));
      if (feature.IsPublished)
      {
        destination.Features.Add(ToFeature(feature));
      }
    }

    foreach (LineageLanguageEntity lineageLanguage in source.Languages)
    {
      LanguageEntity language = lineageLanguage.Language
        ?? throw new ArgumentException($"The language is required (LineageId={lineageLanguage.LineageId}, LanguageId={lineageLanguage.LanguageId}).", nameof(source));
      if (language.IsPublished)
      {
        destination.Languages.Items.Add(ToLanguage(language));
      }
    }
    destination.Languages.Extra = source.ExtraLanguages;
    destination.Languages.Text = source.LanguagesText;

    MapAggregate(source, destination);

    return destination;
  }

  public ScriptModel ToScript(ScriptEntity source)
  {
    ScriptModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    MapAggregate(source, destination);

    return destination;
  }

  public SkillModel ToSkill(SkillEntity source) => ToSkill(source, attribute: null);
  public SkillModel ToSkill(SkillEntity source, AttributeModel? attribute)
  {
    SkillModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (attribute is not null)
    {
      destination.Attribute = attribute;
    }
    else if (source.Attribute is null)
    {
      if (source.AttributeId.HasValue)
      {
        throw new ArgumentException("The attribute is required.", nameof(source));
      }
    }
    else if (source.Attribute.IsPublished)
    {
      destination.Attribute = ToAttribute(source.Attribute);
    }

    MapAggregate(source, destination);

    return destination;
  }

  public SpecializationModel ToSpecialization(SpecializationEntity source)
  {
    SpecializationModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.MandatoryTalent is not null)
    {
      if (source.MandatoryTalent.IsPublished)
      {
        destination.Requirements.Talent = ToTalent(source.MandatoryTalent);
      }
    }
    else if (source.MandatoryTalentId.HasValue)
    {
      throw new ArgumentException("The mandatory talent is required.", nameof(source));
    }
    if (source.OtherRequirements is not null)
    {
      destination.Requirements.Other.AddRange(SplitOnNewLine(source.OtherRequirements));
    }

    foreach (SpecializationOptionalTalentEntity optionalTalent in source.OptionalTalents)
    {
      TalentEntity talent = optionalTalent.Talent
        ?? throw new ArgumentException($"The optional talent is required (SpecializationId={optionalTalent.SpecializationId}, TalentId={optionalTalent.TalentId}).", nameof(source)); ;
      if (talent.IsPublished)
      {
        destination.Options.Talents.Add(ToTalent(talent));
      }
    }
    if (source.OtherOptions is not null)
    {
      destination.Options.Other.AddRange(SplitOnNewLine(source.OtherOptions));
    }

    if (source.ReservedTalentName is not null)
    {
      destination.ReservedTalent = new ReservedTalent(source.ReservedTalentName);
      if (source.ReservedTalentDescription is not null)
      {
        destination.ReservedTalent.Description.AddRange(SplitOnNewLine(source.ReservedTalentDescription));
      }
      foreach (SpecializationDiscountedTalentEntity discountedTalent in source.DiscountedTalents)
      {
        TalentEntity talent = discountedTalent.Talent
          ?? throw new ArgumentException($"The discounted talent is required (SpecializationId={discountedTalent.SpecializationId}, TalentId={discountedTalent.TalentId}).", nameof(source)); ;
        if (talent.IsPublished)
        {
          destination.ReservedTalent.DiscountedTalents.Add(ToTalent(talent));
        }
      }
      foreach (SpecializationFeatureEntity specializationFeature in source.Features)
      {
        FeatureEntity feature = specializationFeature.Feature
          ?? throw new ArgumentException($"The feature is required (SpecializationId={specializationFeature.SpecializationId}, FeatureId={specializationFeature.FeatureId}).", nameof(source));
        if (feature.IsPublished)
        {
          destination.ReservedTalent.Features.Add(ToFeature(feature));
        }
      }
    }

    MapAggregate(source, destination);

    return destination;
  }

  public SpellModel ToSpell(SpellEntity source)
  {
    SpellModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    foreach (SpellLevelEntity level in source.Levels)
    {
      if (level.IsPublished)
      {
        destination.Levels.Add(ToSpellLevel(level));
      }
    }

    MapAggregate(source, destination);

    return destination;
  }
  public static SpellLevelModel ToSpellLevel(SpellLevelEntity source)
  {
    SpellLevelModel destination = new()
    {
      Level = source.Level,
      Name = source.Name
    };

    destination.Casting.Time = source.CastingTime;
    destination.Casting.IsRitual = source.IsRitual;

    if (source.Duration.HasValue && source.DurationUnit.HasValue)
    {
      destination.Duration = new SpellDurationModel
      {
        Value = source.Duration.Value,
        Unit = source.DurationUnit.Value,
        IsConcentration = source.IsConcentration
      };
    }

    destination.Range = source.Range;

    destination.Components.IsSomatic = source.IsSomatic;
    destination.Components.IsVerbal = source.IsVerbal;
    destination.Components.Focus = source.Focus;
    destination.Components.Material = source.Material;

    destination.Description = source.Description;

    return destination;
  }

  public StatisticModel ToStatistic(StatisticEntity source) => ToStatistic(source, attribute: null);
  public StatisticModel ToStatistic(StatisticEntity source, AttributeModel? attribute)
  {
    StatisticModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (attribute is not null)
    {
      destination.Attribute = attribute;
    }
    else if (source.Attribute is null)
    {
      throw new ArgumentException("The attribute is required.", nameof(source));
    }
    else if (source.Attribute.IsPublished)
    {
      destination.Attribute = ToAttribute(source.Attribute);
    }

    MapAggregate(source, destination);

    return destination;
  }

  public TalentModel ToTalent(TalentEntity source)
  {
    TalentModel destination = new()
    {
      Id = source.Id,
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
      if (source.Skill.IsPublished)
      {
        destination.Skill = ToSkill(source.Skill);
      }
    }
    else if (source.SkillId.HasValue)
    {
      throw new ArgumentException("The skill is required.", nameof(source));
    }

    if (source.RequiredTalent is not null && source.RequiredTalent.IsPublished)
    {
      destination.RequiredTalent = ToTalent(source.RequiredTalent);
    }

    MapAggregate(source, destination);

    return destination;
  }

  private void MapAggregate(AggregateEntity source, Aggregate destination)
  {
    destination.Version = source.Version;

    destination.CreatedBy = TryFindActor(source.CreatedBy) ?? _system;
    destination.CreatedOn = source.CreatedOn.AsUniversalTime();

    destination.UpdatedBy = TryFindActor(source.UpdatedBy) ?? _system;
    destination.UpdatedOn = source.UpdatedOn.AsUniversalTime();
  }

  private Actor? TryFindActor(string? id) => TryFindActor(string.IsNullOrWhiteSpace(id) ? null : new ActorId(id));
  private Actor? TryFindActor(ActorId? id) => id.HasValue && _actors.TryGetValue(id.Value, out Actor? actor) ? actor : null;

  private static IReadOnlyCollection<string> SplitOnNewLine(string text) => text.Remove("\r").Split('\n')
    .Where(x => !string.IsNullOrWhiteSpace(x))
    .Select(x => x.Trim())
    .ToList().AsReadOnly();
}
