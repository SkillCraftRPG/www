using Krakenar.Core.Contents.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers.Materialization;

internal record EducationUnpublished(ContentLocaleUnpublished Event) : INotification;

internal class EducationUnpublishedHandler : INotificationHandler<EducationUnpublished>
{
  private readonly RuleContext _rules;

  public EducationUnpublishedHandler(RuleContext rules)
  {
    _rules = rules;
  }

  public async Task Handle(EducationUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.Event.StreamId.Value;
    await _rules.Educations.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
  }
}
