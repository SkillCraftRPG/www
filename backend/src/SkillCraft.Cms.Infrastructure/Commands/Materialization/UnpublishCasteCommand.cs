using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishCasteCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishCasteCommandHandler : ICommandHandler<UnpublishCasteCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishCasteCommandHandler> _logger;

  public UnpublishCasteCommandHandler(RulesContext context, ILogger<UnpublishCasteCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishCasteCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    CasteEntity? caste = await _context.Castes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (caste is null)
    {
      _logger.LogWarning("The caste 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      caste.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The caste 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
