using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishLineageCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishLineageCommandHandler : ICommandHandler<UnpublishLineageCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishLineageCommandHandler> _logger;

  public UnpublishLineageCommandHandler(RulesContext context, ILogger<UnpublishLineageCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishLineageCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    LineageEntity? lineage = await _context.Lineages.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (lineage is null)
    {
      _logger.LogWarning("The lineage 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      lineage.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The lineage 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
