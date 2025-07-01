using Krakenar.Core.Contents;
using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using SkillCraft.Infrastructure.Data;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class StatisticEntity : AggregateEntity
{
  public int StatisticId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public GameStatistic Value { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public AttributeEntity? Attribute { get; private set; }
  public int? AttributeId { get; private set; }
  public Guid? AttributeUid { get; set; }

  public StatisticEntity(StatisticPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private StatisticEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds() => GetActorIds(skipAttribute: false);
  public IReadOnlyCollection<ActorId> GetActorIds(bool skipAttribute)
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (!skipAttribute && Attribute is not null)
    {
      actorIds.AddRange(Attribute.GetActorIds(skipSkills: false, skipStatistics: true));
    }
    return actorIds.AsReadOnly();
  }

  public void SetAttribute(AttributeEntity? attribute)
  {
    Attribute = attribute;
    AttributeId = attribute?.AttributeId;
    AttributeUid = attribute?.Id;
  }

  public void Update(StatisticPublished published)
  {
    base.Update(published.Event);

    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Statistics.Slug).ToLowerInvariant();

    if (!Enum.TryParse(locale.UniqueName.Value, out GameStatistic value))
    {
      throw new ArgumentException($"The value '{locale.UniqueName.Value}' is not a valid game attribute.", nameof(published));
    }
    Value = value;

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Statistics.Summary);
    Description = locale.TryGetStringValue(Statistics.Description);
  }
}
