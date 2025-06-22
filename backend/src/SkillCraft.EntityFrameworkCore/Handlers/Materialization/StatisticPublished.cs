using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record StatisticPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class StatisticPublishedHandler : INotificationHandler<StatisticPublished>
{
  private readonly ILogger<StatisticPublishedHandler> _logger;
  private readonly RuleContext _rules;

  public StatisticPublishedHandler(ILogger<StatisticPublishedHandler> logger, RuleContext rules)
  {
    _logger = logger;
    _rules = rules;
  }

  public async Task Handle(StatisticPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    StatisticEntity? statistic = await _rules.Statistics.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (statistic is null)
    {
      statistic = new StatisticEntity(@event);

      _rules.Statistics.Add(statistic);
    }
    else
    {
      statistic.Update(@event);
    }

    IReadOnlyCollection<Guid>? attributeIds = @event.Invariant.TryGetRelatedContentValue(Fields.Statistics.Attribute);
    if (attributeIds is not null)
    {
      if (attributeIds.Count < 1)
      {
        _logger.LogWarning("Invalid attribute field value for content 'Id={StreamId}', there was no related content.", streamId);
      }
      else if (attributeIds.Count > 1)
      {
        _logger.LogWarning("Invalid attribute field value for content 'Id={StreamId}', there were {Count} related contents.", streamId, attributeIds.Count);
      }
      else
      {
        Guid attributeId = attributeIds.Single();
        AttributeEntity? attribute = await _rules.Attributes.SingleOrDefaultAsync(x => x.Id == attributeId, cancellationToken);
        if (attribute is null)
        {
          statistic.AttributeUid = attributeId;
        }
        else
        {
          statistic.SetAttribute(attribute);
        }
      }
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
