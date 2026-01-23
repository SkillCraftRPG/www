using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishCollectionCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishCollectionCommandHandler : ICommandHandler<UnpublishCollectionCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishCollectionCommandHandler> _logger;

  public UnpublishCollectionCommandHandler(RulesContext context, ILogger<UnpublishCollectionCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishCollectionCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    CollectionEntity? collection = await _context.Collections.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (collection is null)
    {
      _logger.LogWarning("The caste 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      collection.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The caste 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
