using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishCustomizationCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishCustomizationCommandHandler : ICommandHandler<UnpublishCustomizationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishCustomizationCommandHandler> _logger;

  public UnpublishCustomizationCommandHandler(RulesContext context, ILogger<UnpublishCustomizationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishCustomizationCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    CustomizationEntity? customization = await _context.Customizations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (customization is null)
    {
      _logger.LogWarning("The customization 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      customization.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The customization 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
