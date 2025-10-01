using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Contracts;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class AttributeEntity : AggregateEntity
{
  public int AttributeId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; set; } = string.Empty;

  public AttributeCategory? Category { get; set; }
  public GameAttribute Value { get; set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public List<StatisticEntity> Statistics { get; private set; } = [];
  public List<SkillEntity> Skills { get; private set; } = [];

  public AttributeEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private AttributeEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds() => GetActorIds(skipStatistics: false, skipSkills: false);
  public IReadOnlyCollection<ActorId> GetActorIds(bool skipStatistics, bool skipSkills)
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (!skipStatistics)
    {
      foreach (StatisticEntity statistic in Statistics)
      {
        actorIds.AddRange(statistic.GetActorIds(skipAttribute: true));
      }
    }
    if (!skipSkills)
    {
      foreach (SkillEntity skill in Skills)
      {
        actorIds.AddRange(skill.GetActorIds(skipAttribute: true));
      }
    }
    return actorIds;
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
