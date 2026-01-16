using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishSpellCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishSpellCommandHandler : ICommandHandler<PublishSpellCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishSpellCommandHandler> _logger;

  public PublishSpellCommandHandler(RulesContext context, ILogger<PublishSpellCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishSpellCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    SpellEntity? spell = await _context.Spells.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (spell is null)
    {
      spell = new SpellEntity(command.Event);
      _context.Spells.Add(spell);
    }

    spell.Slug = locale.GetString(Spells.Slug);
    spell.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    spell.Tier = (int)invariant.GetNumber(Spells.Tier);

    spell.Summary = locale.TryGetString(Spells.Summary);
    spell.MetaDescription = locale.TryGetString(Spells.MetaDescription);
    spell.Description = locale.TryGetString(Spells.HtmlContent);

    spell.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The spell '{Spell}' has been published.", spell);

    return new CommandResult();
  }
}
