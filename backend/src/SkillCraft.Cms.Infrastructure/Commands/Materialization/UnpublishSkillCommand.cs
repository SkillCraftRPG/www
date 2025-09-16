using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishSkillCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishSkillCommandHandler : ICommandHandler<UnpublishSkillCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishSkillCommandHandler> _logger;

  public UnpublishSkillCommandHandler(RulesContext context, ILogger<UnpublishSkillCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishSkillCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    SkillEntity? skill = await _context.Skills.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (skill is null)
    {
      _logger.LogWarning("The skill 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      skill.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The skill 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
