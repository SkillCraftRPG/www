using Krakenar.Core.Contents;
using Logitar.EventSourcing;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using SkillCraft.Infrastructure.Data;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class AttributeEntity : AggregateEntity
{
  public int AttributeId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public GameAttribute Value { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public List<SkillEntity> Skills { get; private set; } = [];
  public List<StatisticEntity> Statistics { get; private set; } = [];

  public AttributeEntity(AttributePublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private AttributeEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds() => GetActorIds(skipSkills: false, skipStatistics: false);
  public IReadOnlyCollection<ActorId> GetActorIds(bool skipSkills, bool skipStatistics)
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (!skipSkills)
    {
      foreach (SkillEntity skill in Skills)
      {
        actorIds.AddRange(skill.GetActorIds(skipAttribute: true));
      }
    }
    if (!skipStatistics)
    {
      foreach (StatisticEntity statistic in Statistics)
      {
        actorIds.AddRange(statistic.GetActorIds(skipAttribute: true));
      }
    }
    return actorIds.AsReadOnly();
  }

  public void Update(AttributePublished published)
  {
    base.Update(published.Event);

    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Attributes.Slug).ToLowerInvariant();

    if (!Enum.TryParse(locale.UniqueName.Value, out GameAttribute value))
    {
      throw new ArgumentException($"The value '{locale.UniqueName.Value}' is not a valid game attribute.", nameof(published));
    }
    Value = value;

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Attributes.Summary);
    Description = locale.TryGetStringValue(Attributes.Description);
  }
}
