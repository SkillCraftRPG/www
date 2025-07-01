using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Entities.Rules;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record SkillPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class SkillPublishedHandler : INotificationHandler<SkillPublished>
{
  private readonly ILogger<SkillPublishedHandler> _logger;
  private readonly RuleContext _rules;

  public SkillPublishedHandler(ILogger<SkillPublishedHandler> logger, RuleContext rules)
  {
    _logger = logger;
    _rules = rules;
  }

  public async Task Handle(SkillPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    SkillEntity? skill = await _rules.Skills.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (skill is null)
    {
      skill = new SkillEntity(@event);

      _rules.Skills.Add(skill);
    }
    else
    {
      skill.Update(@event);
    }

    IReadOnlyCollection<Guid>? attributeIds = @event.Invariant.TryGetRelatedContentValue(Skills.Attribute);
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
          skill.AttributeUid = attributeId;
        }
        else
        {
          skill.SetAttribute(attribute);
        }
      }
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
