using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishScriptCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishScriptCommandHandler : ICommandHandler<PublishScriptCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishScriptCommandHandler> _logger;

  public PublishScriptCommandHandler(RulesContext context, ILogger<PublishScriptCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishScriptCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    ScriptEntity? script = await _context.Scripts.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (script is null)
    {
      script = new ScriptEntity(command.Event);
      _context.Scripts.Add(script);
    }

    script.Slug = locale.GetString(Scripts.Slug);
    script.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    script.Summary = locale.TryGetString(Scripts.Summary);
    script.MetaDescription = locale.Description?.ToMetaDescription();
    script.Description = locale.TryGetString(Scripts.HtmlContent);

    script.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The script '{Script}' has been published.", script);

    return new CommandResult();
  }
}
