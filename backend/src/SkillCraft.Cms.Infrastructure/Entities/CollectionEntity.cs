using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class CollectionEntity : AggregateEntity
{
  public int CollectionId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  // TODO(fpion): UniqueName
  // TODO(fpion): DisplayName
  // TODO(fpion): Description
  public string Name { get; set; } = string.Empty;

  public CollectionEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private CollectionEntity() : base()
  {
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
