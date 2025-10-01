using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class TalentEntity : AggregateEntity
{
  public int TalentId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }
  public bool AllowMultiplePurchases { get; set; }

  public SkillEntity? Skill { get; private set; }
  public int? SkillId { get; private set; }
  public Guid? SkillUid { get; private set; }

  public TalentEntity? RequiredTalent { get; private set; }
  public int? RequiredTalentId { get; private set; }
  public Guid? RequiredTalentUid { get; private set; }
  public List<TalentEntity> RequiringTalents { get; private set; } = [];

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public List<SpecializationEntity> SpecializationsMandatory { get; private set; } = [];
  public List<SpecializationOptionalTalentEntity> SpecializationsOptional { get; private set; } = [];
  public List<SpecializationDiscountedTalentEntity> SpecializationsDiscounted { get; private set; } = [];

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
    if (Skill is not null)
    {
      actorIds.AddRange(Skill.GetActorIds());
    }
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

  public void SetSkill(SkillEntity? skill)
  {
    Skill = skill;
    SkillId = skill?.SkillId;
    SkillUid = skill?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
