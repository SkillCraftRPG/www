using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishSpecializationCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishSpecializationCommandHandler : ICommandHandler<UnpublishSpecializationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishSpecializationCommandHandler> _logger;

  public UnpublishSpecializationCommandHandler(RulesContext context, ILogger<UnpublishSpecializationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishSpecializationCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    SpecializationEntity? specialization = await _context.Specializations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (specialization is null)
    {
      _logger.LogWarning("The specialization 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      specialization.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The specialization 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
