using Krakenar.Core.Contents;
using Logitar.EventSourcing;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using SkillCraft.Infrastructure.Data;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class EducationEntity : AggregateEntity
{
  public int EducationId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public SkillEntity? Skill { get; private set; }
  public int? SkillId { get; private set; }
  public Guid? SkillUid { get; set; }

  public int? WealthMultiplier { get; private set; }

  public string? Feature { get; private set; }

  public EducationEntity(EducationPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private EducationEntity() : base()
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

  public void Update(EducationPublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Educations.Slug).ToLowerInvariant();

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Educations.Summary);
    Description = locale.TryGetStringValue(Educations.Description);

    WealthMultiplier = (int)invariant.FindNumberValue(Educations.WealthMultiplier);

    Feature = locale.TryGetStringValue(Educations.Feature);
  }
}
