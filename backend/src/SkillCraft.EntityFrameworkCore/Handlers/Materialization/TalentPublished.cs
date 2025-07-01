using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Entities.Rules;
using SkillCraft.Infrastructure.Data;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record TalentPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class TalentPublishedHandler : INotificationHandler<TalentPublished>
{
  private readonly ILogger<TalentPublishedHandler> _logger;
  private readonly RuleContext _rules;

  public TalentPublishedHandler(ILogger<TalentPublishedHandler> logger, RuleContext rules)
  {
    _logger = logger;
    _rules = rules;
  }

  public async Task Handle(TalentPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    TalentEntity? talent = await _rules.Talents.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (talent is null)
    {
      talent = new TalentEntity(@event);

      _rules.Talents.Add(talent);
    }
    else
    {
      talent.Update(@event);
    }

    IReadOnlyCollection<Guid>? skillIds = @event.Invariant.TryGetRelatedContentValue(Talents.Skill);
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
          talent.SkillUid = skillId;
        }
        else
        {
          talent.SetSkill(skill);
        }
      }
    }

    IReadOnlyCollection<Guid>? requiredTalentIds = @event.Invariant.TryGetRelatedContentValue(Talents.RequiredTalent);
    if (requiredTalentIds is not null)
    {
      if (requiredTalentIds.Count < 1)
      {
        _logger.LogWarning("Invalid required talent field value for content 'Id={StreamId}', there was no related content.", streamId);
      }
      else if (requiredTalentIds.Count > 1)
      {
        _logger.LogWarning("Invalid required talent field value for content 'Id={StreamId}', there were {Count} related contents.", streamId, requiredTalentIds.Count);
      }
      else
      {
        Guid requiredTalentId = requiredTalentIds.Single();
        TalentEntity? requiredTalent = await _rules.Talents.SingleOrDefaultAsync(x => x.Id == requiredTalentId, cancellationToken);
        if (requiredTalent is null)
        {
          talent.RequiredTalentUid = requiredTalentId;
        }
        else
        {
          talent.SetRequiredTalent(requiredTalent);
        }
      }
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
