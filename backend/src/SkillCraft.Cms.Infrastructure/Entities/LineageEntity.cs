using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Contracts;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class LineageEntity : AggregateEntity
{
  public int LineageId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; set; } = string.Empty;

  public LineageEntity? Parent { get; private set; }
  public int? ParentId { get; private set; }
  public Guid? ParentUid { get; private set; }

  public int ExtraLanguages { get; set; }
  public string? LanguagesText { get; set; }

  public string? Names { get; set; }

  public int Walk { get; set; }
  public int Climb { get; set; }
  public int Swim { get; set; }
  public int Fly { get; set; }
  public bool Hover { get; set; }
  public int Burrow { get; set; }

  public SizeCategory SizeCategory { get; set; }
  public string? SizeRoll { get; set; }

  public string? Malnutrition { get; set; }
  public string? Skinny { get; set; }
  public string? NormalWeight { get; set; }
  public string? Overweight { get; set; }
  public string? Obese { get; set; }

  public int Teenager { get; set; }
  public int Adult { get; set; }
  public int Mature { get; set; }
  public int Venerable { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public List<LineageEntity> Children { get; private set; } = [];
  public List<LineageFeatureEntity> Features { get; private set; } = [];
  public List<LineageLanguageEntity> Languages { get; private set; } = [];

  public LineageEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private LineageEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (Parent is not null)
    {
      actorIds.AddRange(Parent.GetActorIds());
    }
    foreach (LineageFeatureEntity relation in Features)
    {
      if (relation.Feature is not null)
      {
        actorIds.AddRange(relation.Feature.GetActorIds());
      }
    }
    foreach (LineageLanguageEntity relation in Languages)
    {
      if (relation.Language is not null)
      {
        actorIds.AddRange(relation.Language.GetActorIds());
      }
    }
    return actorIds.AsReadOnly();
  }

  public void AddFeature(FeatureEntity feature)
  {
    Features.Add(new LineageFeatureEntity(this, feature));
  }
  public void AddLanguage(LanguageEntity language)
  {
    Languages.Add(new LineageLanguageEntity(this, language));
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetParent(LineageEntity? parent)
  {
    Parent = parent;
    ParentId = parent?.LineageId;
    ParentUid = parent?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public AgeModel GetAge() => new(Teenager, Adult, Mature, Venerable);

  public NamesModel GetNames()
  {
    return (Names is null ? null : JsonSerializer.Deserialize<NamesModel>(Names)) ?? new();
  }
  public void SetNames(NamesModel names)
  {
    if (!string.IsNullOrWhiteSpace(names.Text) || names.Family.Count > 0 || names.Female.Count > 0 || names.Male.Count > 0 || names.Unisex.Count > 0)
    {
      Names = JsonSerializer.Serialize(names);
    }
    else
    {
      Names = null;
    }
  }

  public SizeModel GetSize() => new(SizeCategory, SizeRoll);

  public SpeedsModel GetSpeeds() => new(Walk, Climb, Swim, Fly, Burrow, Hover);

  public WeightModel GetWeight() => new(Malnutrition, Skinny, NormalWeight, Overweight, Obese);

  public override string ToString() => $"{Name} | {base.ToString()}";
}
