using FluentValidation;
using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.Core.Localization;
using Krakenar.EntityFrameworkCore.Relational;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Commands;
using SkillCraft.Cms.Infrastructure.Commands.Attributes;
using SkillCraft.Cms.Infrastructure.Commands.Talents;
using Stream = Logitar.EventSourcing.Stream;

namespace SkillCraft.Cms.Infrastructure.Handlers;

internal class ContentMaterializationEvents : IEventHandler<ContentLocalePublished>, IEventHandler<ContentLocaleUnpublished>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<ContentLocalePublished>, ContentMaterializationEvents>();
    services.AddTransient<IEventHandler<ContentLocaleUnpublished>, ContentMaterializationEvents>();

    services.AddTransient<ICommandHandler<PublishAttributeCommand, CommandResult>, PublishAttributeCommandHandler>();
    services.AddTransient<ICommandHandler<PublishTalentCommand, CommandResult>, PublishTalentCommandHandler>();
    services.AddTransient<ICommandHandler<UnpublishAttributeCommand, CommandResult>, UnpublishAttributeCommandHandler>();
    services.AddTransient<ICommandHandler<UnpublishTalentCommand, CommandResult>, UnpublishTalentCommandHandler>();
  }

  private readonly ICommandBus _commandBus;
  private readonly IEventStore _events;
  private readonly KrakenarContext _krakenar;
  private readonly ILogger<ContentMaterializationEvents> _logger;

  public ContentMaterializationEvents(ICommandBus commandBus, IEventStore events, KrakenarContext krakenar, ILogger<ContentMaterializationEvents> logger)
  {
    _commandBus = commandBus;
    _events = events;
    _krakenar = krakenar;
    _logger = logger;
  }

  public async Task HandleAsync(ContentLocalePublished @event, CancellationToken cancellationToken)
  {
    ContentId contentId = new(@event.StreamId);
    if (contentId.RealmId.HasValue)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because it has a realm ID.", @event.Id);
      return;
    }

    string? defaultLanguageStreamId = await _krakenar.Languages.AsNoTracking()
      .Where(x => x.RealmId == null && x.IsDefault)
      .Select(x => x.StreamId)
      .SingleOrDefaultAsync(cancellationToken);
    if (string.IsNullOrWhiteSpace(defaultLanguageStreamId))
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because the defaut language was not found.", @event.Id);
      return;
    }
    LanguageId defaultLanguageId = new(defaultLanguageStreamId);
    if (@event.LanguageId.HasValue && @event.LanguageId.Value != defaultLanguageId)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignore because the language 'Id={LanguageId}' is not tracked.", @event.Id, @event.LanguageId.Value);
      return;
    }

    string? contentType = await _krakenar.Contents.AsNoTracking()
      .Include(x => x.ContentType)
      .Where(x => x.StreamId == @event.StreamId.Value)
      .Select(x => x.ContentType!.UniqueName)
      .SingleOrDefaultAsync(cancellationToken);
    if (string.IsNullOrWhiteSpace(contentType) || !Enum.TryParse(contentType.Trim(), ignoreCase: true, out EntityKind kind) || !Enum.IsDefined(kind))
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because its content type '{ContentType}' is not tracked.", @event.Id, contentType);
      return;
    }

    FetchOptions options = new()
    {
      ToVersion = @event.Version,
      IsDeleted = false
    };
    Stream? stream = await _events.FetchAsync(@event.StreamId, options, cancellationToken);
    if (stream is null)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because its stream 'Id={StreamId}' was not found.", @event.Id, @event.StreamId);
      return;
    }

    ContentLocale? latestInvariant = null;
    ContentLocale? latestLocale = null;
    ContentLocale? publishedInvariant = null;
    ContentLocale? publishedLocale = null;
    foreach (Event change in stream.Events)
    {
      if (change.Data is ContentCreated created)
      {
        latestInvariant = created.Invariant;
      }
      else if (change.Data is ContentLocaleChanged changed)
      {
        if (changed.LanguageId is null)
        {
          latestInvariant = changed.Locale;
        }
        else if (changed.LanguageId == defaultLanguageId)
        {
          latestLocale = changed.Locale;
        }
      }
      else if (change.Data is ContentLocalePublished published)
      {
        if (published.LanguageId is null)
        {
          publishedInvariant = latestInvariant;
        }
        else if (published.LanguageId == defaultLanguageId)
        {
          publishedLocale = latestLocale;
        }
      }
      else if (change.Data is ContentLocaleRemoved removed)
      {
        if (removed.LanguageId == defaultLanguageId)
        {
          latestLocale = null;
          publishedLocale = null;
        }
      }
      else if (change.Data is ContentLocaleUnpublished unpublished)
      {
        if (unpublished.LanguageId is null)
        {
          publishedInvariant = null;
        }
        else if (unpublished.LanguageId == defaultLanguageId)
        {
          publishedLocale = null;
        }
      }
    }
    if (publishedInvariant is null)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because the invariant is not published.", @event.Id);
      return;
    }
    else if (publishedLocale is null)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because the locale is not published.", @event.Id);
      return;
    }

    switch (kind)
    {
      case EntityKind.Attribute:
        await _commandBus.ExecuteAsync(new PublishAttributeCommand(@event, publishedInvariant, publishedLocale), cancellationToken);
        break;
      case EntityKind.Talent:
        await _commandBus.ExecuteAsync(new PublishTalentCommand(@event, publishedInvariant, publishedLocale), cancellationToken);
        break;
      default:
        _logger.LogWarning("Event 'Id={EventId}' is being ignored because the entity kind '{Kind}' is not supported.", @event.Id, kind);
        return;
    }

    _logger.LogInformation("Event 'Id={EventId}' handled successfully.", @event.Id);
  }

  public async Task HandleAsync(ContentLocaleUnpublished @event, CancellationToken cancellationToken)
  {
    ContentId contentId = new(@event.StreamId);
    if (contentId.RealmId.HasValue)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because it has a realm ID.", @event.Id);
      return;
    }

    string? defaultLanguageStreamId = await _krakenar.Languages.AsNoTracking()
      .Where(x => x.RealmId == null && x.IsDefault)
      .Select(x => x.StreamId)
      .SingleOrDefaultAsync(cancellationToken);
    if (string.IsNullOrWhiteSpace(defaultLanguageStreamId))
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because the defaut language was not found.", @event.Id);
      return;
    }
    LanguageId defaultLanguageId = new(defaultLanguageStreamId);
    if (@event.LanguageId.HasValue && @event.LanguageId.Value != defaultLanguageId)
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignore because the language 'Id={LanguageId}' is not tracked.", @event.Id, @event.LanguageId.Value);
      return;
    }

    string? contentType = await _krakenar.Contents.AsNoTracking()
      .Include(x => x.ContentType)
      .Where(x => x.StreamId == @event.StreamId.Value)
      .Select(x => x.ContentType!.UniqueName)
      .SingleOrDefaultAsync(cancellationToken);
    if (string.IsNullOrWhiteSpace(contentType) || !Enum.TryParse(contentType.Trim(), ignoreCase: true, out EntityKind kind) || !Enum.IsDefined(kind))
    {
      _logger.LogWarning("Event 'Id={EventId}' is being ignored because its content type '{ContentType}' is not tracked.", @event.Id, contentType);
      return;
    }

    switch (kind)
    {
      case EntityKind.Attribute:
        await _commandBus.ExecuteAsync(new UnpublishAttributeCommand(@event), cancellationToken);
        break;
      case EntityKind.Talent:
        await _commandBus.ExecuteAsync(new UnpublishTalentCommand(@event), cancellationToken);
        break;
      default:
        _logger.LogWarning("Event 'Id={EventId}' is being ignored because the entity kind '{Kind}' is not supported.", @event.Id, kind);
        return;
    }

    _logger.LogInformation("Event 'Id={EventId}' handled successfully.", @event.Id);
  }
}
