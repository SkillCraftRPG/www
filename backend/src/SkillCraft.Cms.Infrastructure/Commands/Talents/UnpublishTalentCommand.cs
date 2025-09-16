using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Talents;

internal record UnpublishTalentCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishTalentCommandHandler : ICommandHandler<UnpublishTalentCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishTalentCommandHandler> _logger;

  public UnpublishTalentCommandHandler(RulesContext context, ILogger<UnpublishTalentCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishTalentCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    TalentEntity? talent = await _context.Talents.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (talent is null)
    {
      _logger.LogWarning("The talent 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      talent.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The talent 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
