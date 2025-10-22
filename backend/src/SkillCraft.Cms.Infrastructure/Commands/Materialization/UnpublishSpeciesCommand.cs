using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishSpeciesCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishSpeciesCommandHandler : ICommandHandler<UnpublishSpeciesCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishSpeciesCommandHandler> _logger;

  public UnpublishSpeciesCommandHandler(RulesContext context, ILogger<UnpublishSpeciesCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishSpeciesCommand command, CancellationToken cancellationToken)
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
