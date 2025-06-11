using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Krakenar.Core.Localization;
using Krakenar.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers;

internal class RuleContentEvents : IEventHandler<ContentLocalePublished>, IEventHandler<ContentLocaleUnpublished>
{
  private readonly KrakenarContext _krakenar;
  private readonly RuleContext _rules;

  public RuleContentEvents(KrakenarContext krakenar, RuleContext rules)
  {
    _krakenar = krakenar;
    _rules = rules;
  }

  public async Task HandleAsync(ContentLocalePublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.StreamId.Value;

    EntityKind? kind = await GetKindAsync(streamId, @event.LanguageId, cancellationToken);
    switch (kind)
    {
      case EntityKind.Talent:
        // TODO(fpion): sync talent
        break;
    }
  }

  public async Task HandleAsync(ContentLocaleUnpublished @event, CancellationToken cancellationToken)
  {
    string streamId = @event.StreamId.Value;

    EntityKind? kind = await GetKindAsync(streamId, @event.LanguageId, cancellationToken);
    switch (kind)
    {
      case EntityKind.Talent:
        await _rules.Talents.Where(x => x.StreamId == streamId).ExecuteDeleteAsync(cancellationToken);
        break;
    }
  }

  private async Task<EntityKind?> GetKindAsync(string streamId, LanguageId? languageId, CancellationToken cancellationToken)
  {
    Guid? languageUid = languageId?.EntityId;

    string? contentType = await _krakenar.ContentLocales.AsNoTracking()
      .Include(x => x.Content).ThenInclude(x => x!.ContentType)
      .Where(x => x.LanguageUid == languageUid && x.Content!.StreamId == streamId)
      .Select(x => x.ContentType!.UniqueName)
      .SingleOrDefaultAsync(cancellationToken);

    return !string.IsNullOrWhiteSpace(contentType) && Enum.TryParse(contentType, out EntityKind kind) ? kind : null;
  }
}
