using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class SpecializationEntity : AggregateEntity
{
  public int SpecializationId { get; private set; }
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

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public TalentEntity? MandatoryTalent { get; private set; }
  public int? MandatoryTalentId { get; private set; }
  public Guid? MandatoryTalentUid { get; private set; }

  public string? OtherRequirements { get; set; }
  public string? OtherOptions { get; set; }

  public string ReservedTalentName { get; set; } = string.Empty;
  public string? ReservedTalentDescription { get; set; }

  public List<SpecializationDiscountedTalentEntity> DiscountedTalents { get; private set; } = [];
  public List<SpecializationFeatureEntity> Features { get; private set; } = [];
  public List<SpecializationOptionalTalentEntity> OptionalTalents { get; private set; } = [];

  public SpecializationEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private SpecializationEntity() : base()
  {
  }

  public void AddDiscountedTalent(TalentEntity talent)
  {
    DiscountedTalents.Add(new SpecializationDiscountedTalentEntity(this, talent));
  }
  public void AddFeature(FeatureEntity feature)
  {
    Features.Add(new SpecializationFeatureEntity(this, feature));
  }
  public void AddOptionalTalent(TalentEntity talent)
  {
    OptionalTalents.Add(new SpecializationOptionalTalentEntity(this, talent));
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (MandatoryTalent is not null)
    {
      actorIds.AddRange(MandatoryTalent.GetActorIds());
    }
    foreach (SpecializationDiscountedTalentEntity discounted in DiscountedTalents)
    {
      if (discounted.Talent is not null)
      {
        actorIds.AddRange(discounted.Talent.GetActorIds());
      }
    }
    foreach (SpecializationFeatureEntity feature in Features)
    {
      if (feature.Feature is not null)
      {
        actorIds.AddRange(feature.Feature.GetActorIds());
      }
    }
    foreach (SpecializationOptionalTalentEntity optional in OptionalTalents)
    {
      if (optional.Talent is not null)
      {
        actorIds.AddRange(optional.Talent.GetActorIds());
      }
    }
    return actorIds.AsReadOnly();
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetMandatoryTalent(TalentEntity? mandatoryTalent)
  {
    MandatoryTalent = mandatoryTalent;
    MandatoryTalentId = mandatoryTalent?.TalentId;
    MandatoryTalentUid = mandatoryTalent?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
