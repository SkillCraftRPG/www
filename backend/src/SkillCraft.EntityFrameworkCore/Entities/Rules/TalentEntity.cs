using Krakenar.Core.Contents.Events;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class TalentEntity : AggregateEntity
{
  public int TalentId { get; private set; }
  public Guid Id { get; private set; }

  public string Alias { get; private set; } = string.Empty;
  public string Name { get; private set; } = string.Empty;
  public string Summary { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;

  public int Tier { get; private set; }
  public bool AllowMultiplePurchases { get; private set; }
  // TODO(fpion): Skill
  // TODO(fpion): RequiredTalent

  public TalentEntity(ContentLocalePublished @event) : base(@event)
  {
    // TODO(fpion): implement
  }

  private TalentEntity() : base()
  {
  }

  public void Update(ContentLocalePublished @event)
  {
    base.Update(@event);

    // TODO(fpion): implement
  }
}
