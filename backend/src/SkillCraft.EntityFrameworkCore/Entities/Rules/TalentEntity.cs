using Krakenar.Core.Contents;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class TalentEntity : AggregateEntity
{
  public int TalentId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public int Tier { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public bool AllowMultiplePurchases { get; private set; }

  public SkillEntity? Skill { get; private set; }
  public int? SkillId { get; private set; }
  public Guid? SkillUid { get; set; }

  public TalentEntity? RequiredTalent { get; private set; }
  public int? RequiredTalentId { get; private set; }
  public Guid? RequiredTalentUid { get; set; }
  public List<TalentEntity> RequiringTalents { get; private set; } = [];

  public TalentEntity(TalentPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private TalentEntity() : base()
  {
  }

  public void SetRequiredTalent(TalentEntity? requiredTalent)
  {
    RequiredTalent = requiredTalent;
    RequiredTalentId = requiredTalent?.RequiredTalentId;
    RequiredTalentUid = requiredTalent?.Id;
  }

  public void SetSkill(SkillEntity? skill)
  {
    Skill = skill;
    SkillId = skill?.SkillId;
    SkillUid = skill?.Id;
  }

  public void Update(TalentPublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Fields.Talents.Slug).ToLowerInvariant();
    Tier = (int)invariant.FindNumberValue(Fields.Talents.Tier);

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Fields.Talents.Summary);
    Description = locale.TryGetStringValue(Fields.Talents.Description);

    AllowMultiplePurchases = invariant.GetBooleanValue(Fields.Talents.AllowMultiplePurchases);
  }
}
