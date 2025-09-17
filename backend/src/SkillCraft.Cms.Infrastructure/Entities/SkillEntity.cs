using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using SkillCraft.Cms.Core;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class SkillEntity : AggregateEntity
{
  public int SkillId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; set; } = string.Empty;

  public GameSkill Value { get; set; }

  public AttributeEntity? Attribute { get; private set; }
  public int? AttributeId { get; private set; }
  public Guid? AttributeUid { get; private set; }

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public SkillEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private SkillEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    // TODO(fpion): Attribute
    return actorIds;
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetAttribute(AttributeEntity? attribute)
  {
    Attribute = attribute;
    AttributeId = attribute?.AttributeId;
    AttributeUid = attribute?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name ?? Slug} | {base.ToString()}";
}
