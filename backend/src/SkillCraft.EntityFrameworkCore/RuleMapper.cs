using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;
using AggregateModel = Krakenar.Contracts.Aggregate;

namespace SkillCraft.EntityFrameworkCore;

internal class RuleMapper
{
  private readonly Dictionary<ActorId, Actor> _actors = [];
  private readonly Actor _system = new();

  public RuleMapper()
  {
  }

  public RuleMapper(IEnumerable<KeyValuePair<ActorId, Actor>> actors)
  {
    foreach (KeyValuePair<ActorId, Actor> actor in actors)
    {
      _actors[actor.Key] = actor.Value;
    }
  }

  public AttributeModel ToAttribute(AttributeEntity source) => ToAttribute(source, skill: null);
  public AttributeModel ToAttribute(AttributeEntity source, SkillModel? skill)
  {
    AttributeModel destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Value = source.Value,
      Name = source.Name,
      Summary = source.Summary,
      Description = source.Description
    };

    if (skill is not null)
    {
      destination.Skills.Add(skill);
    }
    else
    {
      foreach (SkillEntity entity in source.Skills)
      {
        destination.Skills.Add(ToSkill(entity, destination));
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
      Value = source.Value,
      Name = source.Name,
      Summary = source.Summary,
      Description = source.Description
    };

    if (attribute is not null)
    {
      destination.Attribute = attribute;
    }
    else if (source.Attribute is not null)
    {
      destination.Attribute = ToAttribute(source.Attribute, destination);
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
      Tier = source.Tier,
      Name = source.Name,
      Summary = source.Summary,
      Description = source.Description,
      AllowMultiplePurchases = source.AllowMultiplePurchases
    };

    if (source.Skill is not null)
    {
      destination.Skill = ToSkill(source.Skill);
    }
    if (source.RequiredTalent is not null)
    {
      destination.RequiredTalent = ToTalent(source.RequiredTalent);
    }

    MapAggregate(source, destination);

    return destination;
  }

  private void MapAggregate(AggregateEntity source, AggregateModel destination)
  {
    destination.Version = source.Version;

    destination.CreatedBy = FindActor(source.CreatedBy);
    destination.CreatedOn = source.CreatedOn.AsUniversalTime();

    destination.UpdatedBy = FindActor(source.UpdatedBy);
    destination.UpdatedOn = source.UpdatedOn.AsUniversalTime();
  }

  private Actor FindActor(string? id) => TryFindActor(id) ?? _system;
  private Actor FindActor(ActorId? id) => TryFindActor(id) ?? _system;

  private Actor? TryFindActor(string? id) => string.IsNullOrWhiteSpace(id) ? null : TryFindActor(new ActorId(id));
  private Actor? TryFindActor(ActorId? id) => (id.HasValue && _actors.TryGetValue(id.Value, out Actor? actor)) ? actor : null;
}
