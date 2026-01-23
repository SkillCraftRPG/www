using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishArticleCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishArticleCommandHandler : ICommandHandler<PublishArticleCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishArticleCommandHandler> _logger;

  public PublishArticleCommandHandler(RulesContext context, ILogger<PublishArticleCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishArticleCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    ArticleEntity? article = await _context.Articles.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (article is null)
    {
      article = new ArticleEntity(command.Event);
      _context.Articles.Add(article);
    }

    IReadOnlyCollection<Guid> collectionIds = invariant.GetRelatedContents(Articles.Collection);
    CollectionEntity? collection = null;
    if (collectionIds.Count < 1)
    {
      _logger.LogWarning("No collection was provided, when at exactly one is expected, for article '{Article}'.", article);
    }
    else if (collectionIds.Count > 1)
    {
      _logger.LogWarning("Many collections ({Count}) were provided, when at exactly one is expected, for article '{Article}'.", collectionIds.Count, article);
    }
    else
    {
      Guid collectionId = collectionIds.Single();
      collection = await _context.Collections.SingleOrDefaultAsync(x => x.Id == collectionId, cancellationToken);
      if (collection is null)
      {
        _logger.LogWarning("The collection 'Id={CollectionId}' was not found, for article '{Article}'.", collectionId, article);
      }
    }
    article.SetCollection(collection);

    IReadOnlyCollection<Guid>? parentIds = invariant.TryGetRelatedContents(Articles.Parent);
    ArticleEntity? parent = null;
    if (parentIds is not null)
    {
      if (parentIds.Count > 1)
      {
        _logger.LogWarning("Many parents ({Count}) were provided, when at most one is expected, for article '{Article}'.", parentIds.Count, article);
      }
      else if (parentIds.Count == 1)
      {
        Guid parentId = parentIds.Single();
        parent = await _context.Articles.SingleOrDefaultAsync(x => x.Id == parentId, cancellationToken);
        if (parent is null)
        {
          _logger.LogWarning("The parent article 'Id={ParentId}' was not found, for article '{Article}'.", parentId, article);
        }
      }
    }
    article.SetParent(parent);

    article.Slug = locale.GetString(Articles.Slug);
    article.Title = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    article.MetaDescription = locale.TryGetString(Articles.MetaDescription);
    article.HtmlContent = locale.TryGetString(Articles.HtmlContent);

    article.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The caste '{Article}' has been published.", article);

    return new CommandResult();
  }
}
