using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record CastePublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class CastePublishedHandler : INotificationHandler<CastePublished>
{
  private readonly ILogger<CastePublishedHandler> _logger;
  private readonly RuleContext _rules;

  public CastePublishedHandler(ILogger<CastePublishedHandler> logger, RuleContext rules)
  {
    _logger = logger;
    _rules = rules;
  }

  public async Task Handle(CastePublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    CasteEntity? caste = await _rules.Castes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (caste is null)
    {
      caste = new CasteEntity(@event);

      _rules.Castes.Add(caste);
    }
    else
    {
      caste.Update(@event);
    }

    IReadOnlyCollection<Guid>? skillIds = @event.Invariant.TryGetRelatedContentValue(Fields.Castes.Skill);
    if (skillIds is not null)
    {
      if (skillIds.Count < 1)
      {
        _logger.LogWarning("Invalid skill field value for content 'Id={StreamId}', there was no related content.", streamId);
      }
      else if (skillIds.Count > 1)
      {
        _logger.LogWarning("Invalid skill field value for content 'Id={StreamId}', there were {Count} related contents.", streamId, skillIds.Count);
      }
      else
      {
        Guid skillId = skillIds.Single();
        SkillEntity? skill = await _rules.Skills.SingleOrDefaultAsync(x => x.Id == skillId, cancellationToken);
        if (skill is null)
        {
          caste.SkillUid = skillId;
        }
        else
        {
          caste.SetSkill(skill);
        }
      }
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
