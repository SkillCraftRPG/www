using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record CustomizationUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class CustomizationUnpublishedHandler : INotificationHandler<CustomizationUnpublished>
{
  private readonly RuleContext _rules;

  public CustomizationUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(CustomizationUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Customizations.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
