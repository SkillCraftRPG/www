using Krakenar.Core.Contents;
using SkillCraft.EntityFrameworkCore.Handlers.Talents;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class TalentEntity : AggregateEntity
{
  public int TalentId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public string Name { get; private set; } = string.Empty;
  public string Summary { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;

  public int Tier { get; private set; }
  public bool AllowMultiplePurchases { get; private set; }
  // TODO(fpion): Skill

  public TalentEntity? RequiredTalent { get; private set; }
  public int? RequiredTalentId { get; private set; }
  public Guid? RequiredTalentUid { get; private set; }
  public List<TalentEntity> RequiringTalents { get; private set; } = [];

  public TalentEntity(TalentEntity? requiredTalent, TalentPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(requiredTalent, published);
  }

  private TalentEntity() : base()
  {
  }

  public void Update(TalentEntity? requiredTalent, TalentPublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.GetStringValue(Fields.Talents.Slug);
    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.GetStringValue(Fields.Talents.Summary);
    Description = locale.GetStringValue(Fields.Talents.Description);

    Tier = invariant.GetInt32Value(Fields.Talents.Tier);
    AllowMultiplePurchases = invariant.GetBooleanValue(Fields.Talents.AllowMultiplePurchases);
    // TODO(fpion): Skill

    RequiredTalent = requiredTalent;
    RequiredTalentId = requiredTalent?.TalentId;
    RequiredTalentUid = requiredTalent?.Id;
  }
}
