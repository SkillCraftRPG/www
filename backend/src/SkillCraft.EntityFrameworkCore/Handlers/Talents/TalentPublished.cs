using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Handlers.Talents;

internal record TalentPublished(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : INotification;

internal class TalentPublishedHandler : INotificationHandler<TalentPublished>
{
  private readonly RuleContext _rules;

  public TalentPublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(TalentPublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    TalentEntity? talent = await _rules.Talents.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);

    TalentEntity? requiredTalent = null; // TODO(fpion): implement

    if (talent is null)
    {
      talent = new TalentEntity(requiredTalent, @event);

      _rules.Talents.Add(talent);
    }
    else
    {
      talent.Update(requiredTalent, @event);
    }

    await _rules.SaveChangesAsync(cancellationToken);
  }
}
