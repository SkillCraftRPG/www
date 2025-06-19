using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record SkillPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class SkillPublishedHandler : INotificationHandler<SkillPublished>
{
  private readonly RuleContext _rules;

  public SkillPublishedHandler(RuleContext rules)
  {
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

    // TODO(fpion): SetAttribute

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
