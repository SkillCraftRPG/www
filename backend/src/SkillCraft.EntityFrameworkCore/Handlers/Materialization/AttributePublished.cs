using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record AttributePublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class AttributePublishedHandler : INotificationHandler<AttributePublished>
{
  private readonly RuleContext _rules;

  public AttributePublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(AttributePublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    AttributeEntity? attribute = await _rules.Attributes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (attribute is null)
    {
      attribute = new AttributeEntity(@event);

      _rules.Attributes.Add(attribute);
    }
    else
    {
      attribute.Update(@event);
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
