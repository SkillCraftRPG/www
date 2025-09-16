using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishStatisticCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishStatisticCommandHandler : ICommandHandler<UnpublishStatisticCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishStatisticCommandHandler> _logger;

  public UnpublishStatisticCommandHandler(RulesContext context, ILogger<UnpublishStatisticCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishStatisticCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    StatisticEntity? statistic = await _context.Statistics.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (statistic is null)
    {
      _logger.LogWarning("The statistic 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      statistic.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The statistic 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
