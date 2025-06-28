using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record CasteUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class CasteUnpublishedHandler : INotificationHandler<CasteUnpublished>
{
  private readonly RuleContext _rules;

  public CasteUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(CasteUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Castes.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
