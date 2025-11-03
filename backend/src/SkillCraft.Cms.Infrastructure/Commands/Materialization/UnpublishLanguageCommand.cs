using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishLanguageCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishLanguageCommandHandler : ICommandHandler<UnpublishLanguageCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishLanguageCommandHandler> _logger;

  public UnpublishLanguageCommandHandler(RulesContext context, ILogger<UnpublishLanguageCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishLanguageCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    LanguageEntity? language = await _context.Languages.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (language is null)
    {
      _logger.LogWarning("The language 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      language.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The language 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
