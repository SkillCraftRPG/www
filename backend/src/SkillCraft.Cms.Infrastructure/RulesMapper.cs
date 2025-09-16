using Krakenar.Contracts;
using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
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

  public Talent ToTalent(TalentEntity source)
  {
    Talent destination = new()
    {
      Id = source.Id,
      Slug = source.Slug,
      Name = source.Name,
      Tier = source.Tier,
      AllowMultiplePurchases = source.AllowMultiplePurchases,
      Skill = source.Skill,
      Summary = source.Summary,
      Description = source.Description
    };

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
