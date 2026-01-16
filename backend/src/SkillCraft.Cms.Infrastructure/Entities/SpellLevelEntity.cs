using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using SkillCraft.Contracts;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class SpellLevelEntity : AggregateEntity
{
  public int SpellLevelId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public SpellEntity? Spell { get; private set; }
  public int SpellId { get; private set; }
  public Guid SpellUid { get; private set; }

  public int Level { get; set; }
  public string? Name { get; set; }

  public string CastingTime { get; set; } = string.Empty;
  public bool IsRitual { get; set; }

  public int? Duration { get; set; }
  public DurationUnit? DurationUnit { get; set; }
  public bool IsConcentration { get; set; }

  public int Range { get; set; }

  public bool IsSomatic { get; set; }
  public bool IsVerbal { get; set; }
  public string? Focus { get; set; }
  public string? Material { get; set; }

  public string? Description { get; set; }

  public SpellLevelEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private SpellLevelEntity() : base()
  {
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetSpell(SpellEntity spell)
  {
    Spell = spell;
    SpellId = spell.SpellId;
    SpellUid = spell.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
