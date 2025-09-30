using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishFeatureCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishFeatureCommandHandler : ICommandHandler<PublishFeatureCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishFeatureCommandHandler> _logger;

  public PublishFeatureCommandHandler(RulesContext context, ILogger<PublishFeatureCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishFeatureCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    FeatureEntity? feature = await _context.Features.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (feature is null)
    {
      feature = new FeatureEntity(command.Event);
      _context.Features.Add(feature);
    }

    feature.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    feature.Description = locale.TryGetString(Features.HtmlContent);

    feature.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The feature '{Feature}' has been published.", feature);

    return new CommandResult();
  }
}
