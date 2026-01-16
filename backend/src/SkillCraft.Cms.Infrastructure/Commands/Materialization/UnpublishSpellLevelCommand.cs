using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishSpellLevelCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishSpellLevelCommandHandler : ICommandHandler<UnpublishSpellLevelCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishSpellLevelCommandHandler> _logger;

  public UnpublishSpellLevelCommandHandler(RulesContext context, ILogger<UnpublishSpellLevelCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishSpellLevelCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    SpellLevelEntity? spelllevel = await _context.SpellLevels.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (spelllevel is null)
    {
      _logger.LogWarning("The spell level 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      spelllevel.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The spell level 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
