using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishScriptCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishScriptCommandHandler : ICommandHandler<UnpublishScriptCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishScriptCommandHandler> _logger;

  public UnpublishScriptCommandHandler(RulesContext context, ILogger<UnpublishScriptCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishScriptCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    ScriptEntity? script = await _context.Scripts.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (script is null)
    {
      _logger.LogWarning("The script 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      script.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The script 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
