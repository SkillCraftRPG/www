using Krakenar.Contracts;
using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Cms.Core.Skills.Models;
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
}
