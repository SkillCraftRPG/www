using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishFeatureCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishFeatureCommandHandler : ICommandHandler<UnpublishFeatureCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishFeatureCommandHandler> _logger;

  public UnpublishFeatureCommandHandler(RulesContext context, ILogger<UnpublishFeatureCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishFeatureCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    FeatureEntity? feature = await _context.Features.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (feature is null)
    {
      _logger.LogWarning("The feature 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      feature.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The feature 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
