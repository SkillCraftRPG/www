using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishAttributeCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishAttributeCommandHandler : ICommandHandler<UnpublishAttributeCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishAttributeCommandHandler> _logger;

  public UnpublishAttributeCommandHandler(RulesContext context, ILogger<UnpublishAttributeCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishAttributeCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    AttributeEntity? attribute = await _context.Attributes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (attribute is null)
    {
      _logger.LogWarning("The attribute 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      attribute.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The attribute 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
