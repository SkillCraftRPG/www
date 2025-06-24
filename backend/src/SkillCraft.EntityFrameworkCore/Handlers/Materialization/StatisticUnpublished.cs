using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record StatisticUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class StatisticUnpublishedHandler : INotificationHandler<StatisticUnpublished>
{
  private readonly RuleContext _rules;

  public StatisticUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(StatisticUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Statistics.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
