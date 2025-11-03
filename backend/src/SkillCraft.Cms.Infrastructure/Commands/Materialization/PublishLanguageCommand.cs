using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishLanguageCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishLanguageCommandHandler : ICommandHandler<PublishLanguageCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishLanguageCommandHandler> _logger;

  public PublishLanguageCommandHandler(RulesContext context, ILogger<PublishLanguageCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishLanguageCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    LanguageEntity? language = await _context.Languages.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (language is null)
    {
      language = new LanguageEntity(command.Event);
      _context.Languages.Add(language);
    }

    language.Slug = locale.GetString(Languages.Slug);
    language.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    ScriptEntity? script = null;
    IReadOnlyCollection<Guid>? scriptIds = invariant.TryGetRelatedContents(Languages.Script);
    if (scriptIds is not null)
    {
      if (scriptIds.Count > 1)
      {
        _logger.LogWarning("Many scripts ({Count}) were provided, when at most one is expected, for language '{Language}'.", scriptIds.Count, language);
      }
      else if (scriptIds.Count == 1)
      {
        Guid scriptId = scriptIds.Single();
        script = await _context.Scripts.SingleOrDefaultAsync(x => x.Id == scriptId, cancellationToken);
        if (script is null)
        {
          _logger.LogWarning("The script 'Id={ScriptId}' was not found, for language '{Language}'.", scriptId, language);
        }
      }
    }
    language.SetScript(script);

    language.TypicalSpeakers = locale.TryGetString(Languages.TypicalSpeakers);

    language.Summary = locale.TryGetString(Languages.Summary);
    language.MetaDescription = locale.Description?.ToMetaDescription();
    language.Description = locale.TryGetString(Languages.HtmlContent);

    language.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The language '{Language}' has been published.", language);

    return new CommandResult();
  }
}
