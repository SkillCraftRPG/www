using Krakenar.Core.Contents;
using Logitar.EventSourcing;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class CasteEntity : AggregateEntity
{
  public int CasteId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public SkillEntity? Skill { get; private set; }
  public int? SkillId { get; private set; }
  public Guid? SkillUid { get; set; }

  public string? WealthRoll { get; private set; }

  public CasteEntity(CastePublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private CasteEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (Skill is not null)
    {
      actorIds.AddRange(Skill.GetActorIds());
    }
    return actorIds.AsReadOnly();
  }

  public void SetSkill(SkillEntity? skill)
  {
    Skill = skill;
    SkillId = skill?.SkillId;
    SkillUid = skill?.Id;
  }

  public void Update(CastePublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Fields.Castes.Slug).ToLowerInvariant();

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Fields.Castes.Summary);
    Description = locale.TryGetStringValue(Fields.Castes.Description);

    WealthRoll = invariant.FindStringValue(Fields.Castes.WealthRoll);
  }
}
