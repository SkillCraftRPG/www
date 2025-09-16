using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishAttributeCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishAttributeCommandHandler : ICommandHandler<PublishAttributeCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishAttributeCommandHandler> _logger;

  public PublishAttributeCommandHandler(RulesContext context, ILogger<PublishAttributeCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishAttributeCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    AttributeEntity? attribute = await _context.Attributes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (attribute is null)
    {
      attribute = new AttributeEntity(command.Event);
      _context.Attributes.Add(attribute);
    }

    attribute.Slug = locale.GetString(Attributes.Slug);
    attribute.Name = locale.DisplayName?.Value ?? string.Empty;

    AttributeCategory? category = null;
    IReadOnlyCollection<string>? categories = invariant.TryGetSelect(Attributes.Category);
    if (categories is not null)
    {
      if (categories.Count > 1)
      {
        _logger.LogWarning("Many categories ({Count}) were provided, when at most one is expected, for attribute '{Attribute}'.", categories.Count, attribute);
      }
      else if (categories.Count == 1)
      {
        string categoryValue = categories.Single();
        if (Enum.TryParse(categoryValue, out AttributeCategory parsedCategory))
        {
          category = parsedCategory;
        }
        else
        {
          _logger.LogWarning("The category '{Category}' was not parsed, for attribute '{Attribute}'.", categoryValue, attribute);
        }
      }
    }
    attribute.Category = category;

    if (!Enum.TryParse(invariant.UniqueName.Value, out GameAttribute value))
    {
      _logger.LogWarning("The attribute value '{Value}' was not parsed, for attribute '{Attribute}'.", invariant.UniqueName, attribute);
    }
    attribute.Value = value;

    attribute.Summary = locale.TryGetString(Attributes.Summary);
    attribute.Description = locale.TryGetString(Attributes.HtmlContent);

    attribute.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The attribute '{Attribute}' has been published.", attribute);

    return new CommandResult();
  }

  private static string ToName(string slug) => string.Join(' ', slug.Split('-').Select(Capitalize));
  private static string Capitalize(string value) => string.Concat(char.ToUpperInvariant(value.First()), value[1..]);
}
