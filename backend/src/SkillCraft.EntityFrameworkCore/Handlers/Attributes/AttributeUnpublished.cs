using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Attributes;

internal record AttributeUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class AttributeUnpublishedHandler : INotificationHandler<AttributeUnpublished>
{
  private readonly RuleContext _rules;

  public AttributeUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(AttributeUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Attributes.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
