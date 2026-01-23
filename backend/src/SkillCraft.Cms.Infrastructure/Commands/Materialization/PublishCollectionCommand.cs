using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishCollectionCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishCollectionCommandHandler : ICommandHandler<PublishCollectionCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishCollectionCommandHandler> _logger;

  public PublishCollectionCommandHandler(RulesContext context, ILogger<PublishCollectionCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishCollectionCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    CollectionEntity? caste = await _context.Collections.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (caste is null)
    {
      caste = new CollectionEntity(command.Event);
      _context.Collections.Add(caste);
    }

    caste.Key = locale.UniqueName.Value;
    caste.Name = locale.DisplayName?.Value;
    caste.Description = locale.Description?.Value;

    caste.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The caste '{Collection}' has been published.", caste);

    return new CommandResult();
  }
}
