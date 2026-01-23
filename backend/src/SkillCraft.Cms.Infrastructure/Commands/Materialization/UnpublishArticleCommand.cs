using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishArticleCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishArticleCommandHandler : ICommandHandler<UnpublishArticleCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishArticleCommandHandler> _logger;

  public UnpublishArticleCommandHandler(RulesContext context, ILogger<UnpublishArticleCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishArticleCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    ArticleEntity? article = await _context.Articles.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (article is null)
    {
      _logger.LogWarning("The article 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      article.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The article 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
