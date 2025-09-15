using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Logitar.EventSourcing;
using SkillCraft.Core;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class TalentEntity : AggregateEntity // TODO(fpion): property order
{
  public int TalentId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty; // TODO(fpion): normalized?
  public string? Name { get; set; }

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }
  public GameSkill? Skill { get; set; }

  public TalentEntity? RequiredTalent { get; private set; }
  public int? RequiredTalentId { get; private set; }
  public Guid? RequiredTalentUid { get; private set; }
  public List<TalentEntity> RequiringTalents { get; private set; } = [];

  public string? Summary { get; set; }
  public string? Description { get; set; }

  public TalentEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private TalentEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (RequiredTalent is not null)
    {
      actorIds.AddRange(RequiredTalent.GetActorIds());
    }
    return actorIds;
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetRequiredTalent(TalentEntity? requiredTalent)
  {
    RequiredTalent = requiredTalent;
    RequiredTalentId = requiredTalent?.TalentId;
    RequiredTalentUid = requiredTalent?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name ?? Slug} | {base.ToString()}";
}
