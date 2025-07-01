using Krakenar.Core.Contents;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using SkillCraft.Infrastructure.Data;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class CustomizationEntity : AggregateEntity
{
  public int CustomizationId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public CustomizationKind Kind { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public CustomizationEntity(CustomizationPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private CustomizationEntity() : base()
  {
  }

  public void Update(CustomizationPublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Customizations.Slug).ToLowerInvariant();

    IReadOnlyCollection<string> kinds = invariant.FindSelectValue(Customizations.Kind);
    if (kinds.Count < 1)
    {
      throw new InvalidOperationException($"No kind value was provided for customization 'Id={Id}'.");
    }
    else if (kinds.Count > 1)
    {
      throw new InvalidOperationException($"Multiple kind values ({kinds.Count}) were provided for customization 'Id={Id}'.");
    }
    Kind = Enum.Parse<CustomizationKind>(kinds.Single());

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Customizations.Summary);
    Description = locale.TryGetStringValue(Customizations.Description);
  }
}
