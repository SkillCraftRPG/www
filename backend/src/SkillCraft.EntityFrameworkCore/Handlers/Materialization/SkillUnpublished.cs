using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record SkillUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class SkillUnpublishedHandler : INotificationHandler<SkillUnpublished>
{
  private readonly RuleContext _rules;

  public SkillUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(SkillUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Skills.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
