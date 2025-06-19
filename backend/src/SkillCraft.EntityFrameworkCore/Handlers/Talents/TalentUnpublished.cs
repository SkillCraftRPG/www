using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Talents;

internal record TalentUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class TalentUnpublishedHandler : INotificationHandler<TalentUnpublished>
{
  private readonly RuleContext _rules;

  public TalentUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(TalentUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Talents.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
