using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record EducationPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class EducationPublishedHandler : INotificationHandler<EducationPublished>
{
  private readonly ILogger<EducationPublishedHandler> _logger;
  private readonly RuleContext _rules;

  public EducationPublishedHandler(ILogger<EducationPublishedHandler> logger, RuleContext rules)
  {
    _logger = logger;
    _rules = rules;
  }

  public async Task Handle(EducationPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    EducationEntity? education = await _rules.Educations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    if (education is null)
    {
      education = new EducationEntity(@event);

      _rules.Educations.Add(education);
    }
    else
    {
      education.Update(@event);
    }

    IReadOnlyCollection<Guid>? skillIds = @event.Invariant.TryGetRelatedContentValue(Fields.Educations.Skill);
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
          education.SkillUid = skillId;
        }
        else
        {
          education.SetSkill(skill);
        }
      }
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
