using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishSpellCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishSpellCommandHandler : ICommandHandler<UnpublishSpellCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishSpellCommandHandler> _logger;

  public UnpublishSpellCommandHandler(RulesContext context, ILogger<UnpublishSpellCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishSpellCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    SpellEntity? spell = await _context.Spells.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (spell is null)
    {
      _logger.LogWarning("The spell 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      spell.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The spell 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
