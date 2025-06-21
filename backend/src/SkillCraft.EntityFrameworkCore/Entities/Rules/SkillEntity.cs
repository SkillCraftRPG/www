using Krakenar.Core.Contents;
using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class SkillEntity : AggregateEntity
{
  public int SkillId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public GameSkill Value { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public AttributeEntity? Attribute { get; private set; }
  public int? AttributeId { get; private set; }
  public Guid? AttributeUid { get; set; }

  public List<TalentEntity> Talents { get; private set; } = [];

  public SkillEntity(SkillPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private SkillEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds() => GetActorIds(skipAttribute: false);
  public IReadOnlyCollection<ActorId> GetActorIds(bool skipAttribute)
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (!skipAttribute && Attribute is not null)
    {
      actorIds.AddRange(Attribute.GetActorIds(skipSkills: true));
    }
    return actorIds.AsReadOnly();
  }

  public void SetAttribute(AttributeEntity? attribute)
  {
    Attribute = attribute;
    AttributeId = attribute?.AttributeId;
    AttributeUid = attribute?.Id;
  }

  public void Update(SkillPublished published)
  {
    base.Update(published.Event);

    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Fields.Skills.Slug).ToLowerInvariant();

    if (!Enum.TryParse(locale.UniqueName.Value, out GameSkill value))
    {
      throw new ArgumentException($"The value '{locale.UniqueName.Value}' is not a valid game attribute.", nameof(published));
    }
    Value = value;

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Fields.Skills.Summary);
    Description = locale.TryGetStringValue(Fields.Skills.Description);
  }
}
