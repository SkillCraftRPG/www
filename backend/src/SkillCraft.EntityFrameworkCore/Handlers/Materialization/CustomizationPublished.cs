using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record CustomizationPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class CustomizationPublishedHandler : INotificationHandler<CustomizationPublished>
{
  private readonly RuleContext _rules;

  public CustomizationPublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(CustomizationPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    CustomizationEntity? customization = await _rules.Customizations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (customization is null)
    {
      customization = new CustomizationEntity(@event);

      _rules.Customizations.Add(customization);
    }
    else
    {
      customization.Update(@event);
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
