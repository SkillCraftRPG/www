using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishSkillCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishSkillCommandHandler : ICommandHandler<PublishSkillCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishSkillCommandHandler> _logger;

  public PublishSkillCommandHandler(RulesContext context, ILogger<PublishSkillCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishSkillCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    SkillEntity? skill = await _context.Skills.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (skill is null)
    {
      skill = new SkillEntity(command.Event);
      _context.Skills.Add(skill);
    }

    skill.Slug = locale.GetString(Skills.Slug);
    skill.Name = locale.DisplayName?.Value ?? ToName(locale.UniqueName.Value);

    if (!Enum.TryParse(invariant.UniqueName.Value, out GameSkill value))
    {
      _logger.LogWarning("The skill value '{Value}' was not parsed, for skill '{Skill}'.", invariant.UniqueName, skill);
    }
    skill.Value = value;

    AttributeEntity? attribute = null;
    IReadOnlyCollection<Guid>? attributeIds = invariant.TryGetRelatedContents(Skills.Attribute);
    if (attributeIds is not null)
    {
      if (attributeIds.Count > 1)
      {
        _logger.LogWarning("Many attributes ({Count}) were provided, when at most one is expected, for skill '{Skill}'.", attributeIds.Count, skill);
      }
      else if (attributeIds.Count == 1)
      {
        Guid attributeId = attributeIds.Single();
        attribute = await _context.Attributes.SingleOrDefaultAsync(x => x.Id == attributeId, cancellationToken);
        if (attribute is null)
        {
          _logger.LogWarning("The attribute 'Id={AttributeId}' was not found for skill '{Skill}'.", attributeId, skill);
        }
      }
    }
    skill.SetAttribute(attribute);

    skill.Summary = locale.TryGetString(Skills.Summary);
    skill.Description = locale.TryGetString(Skills.HtmlContent);

    skill.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The skill '{Skill}' has been published.", skill);

    return new CommandResult();
  }

  private static string ToName(string slug) => string.Join(' ', slug.Split('-').Select(Capitalize));
  private static string Capitalize(string value) => string.Concat(char.ToUpperInvariant(value.First()), value[1..]);
}
