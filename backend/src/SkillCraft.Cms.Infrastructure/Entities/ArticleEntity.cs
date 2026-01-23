using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class ArticleEntity : AggregateEntity
{
  public int ArticleId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public CollectionEntity? Collection { get; private set; }
  public int? CollectionId { get; private set; }
  public Guid? CollectionUid { get; private set; }

  public ArticleEntity? Parent { get; private set; }
  public int? ParentId { get; private set; }
  public Guid? ParentUid { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Title { get; set; } = string.Empty;

  public string? MetaDescription { get; set; }
  public string? HtmlContent { get; set; }

  public List<ArticleEntity> Children { get; set; } = [];

  public ArticleEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private ArticleEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (Collection is not null)
    {
      actorIds.AddRange(Collection.GetActorIds());
    }
    if (Parent is not null)
    {
      actorIds.AddRange(Parent.GetActorIds());
    }
    return actorIds.AsReadOnly();
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetCollection(CollectionEntity? collection)
  {
    Collection = collection;
    CollectionId = collection?.CollectionId;
    CollectionUid = collection?.Id;
  }

  public void SetParent(ArticleEntity? article)
  {
    Parent = article;
    ParentId = article?.ArticleId;
    ParentUid = article?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Title} | {base.ToString()}";
}
