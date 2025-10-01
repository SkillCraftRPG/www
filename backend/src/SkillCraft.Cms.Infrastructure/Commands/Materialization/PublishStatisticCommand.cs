using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishStatisticCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishStatisticCommandHandler : ICommandHandler<PublishStatisticCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishStatisticCommandHandler> _logger;

  public PublishStatisticCommandHandler(RulesContext context, ILogger<PublishStatisticCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishStatisticCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    StatisticEntity? statistic = await _context.Statistics.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (statistic is null)
    {
      statistic = new StatisticEntity(command.Event);
      _context.Statistics.Add(statistic);
    }

    statistic.Slug = locale.GetString(Statistics.Slug);
    statistic.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    if (!Enum.TryParse(invariant.UniqueName.Value, out GameStatistic value))
    {
      _logger.LogWarning("The statistic value '{Value}' was not parsed, for statistic '{Statistic}'.", invariant.UniqueName, statistic);
    }
    statistic.Value = value;

    IReadOnlyCollection<Guid> attributeIds = invariant.GetRelatedContents(Statistics.Attribute);
    if (attributeIds.Count < 1)
    {
      _logger.LogWarning("No attribute was specified for statistic '{Statistic}'.", statistic);
    }
    else if (attributeIds.Count > 1)
    {
      _logger.LogWarning("Many attributes ({Count}) were provided, when at most one is expected, for statistic '{Statistic}'.", attributeIds.Count, statistic);
    }
    else
    {
      Guid attributeId = attributeIds.Single();
      AttributeEntity? attribute = await _context.Attributes.SingleOrDefaultAsync(x => x.Id == attributeId, cancellationToken);
      if (attribute is null)
      {
        _logger.LogWarning("The attribute 'Id={AttributeId}' was not found for statistic '{Statistic}'.", attributeId, statistic);
      }
      else
      {
        statistic.SetAttribute(attribute);
      }
    }

    statistic.Summary = locale.TryGetString(Statistics.Summary);
    statistic.MetaDescription = locale.Description?.ToMetaDescription();
    statistic.Description = locale.TryGetString(Statistics.HtmlContent);

    statistic.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The statistic '{Statistic}' has been published.", statistic);

    return new CommandResult();
  }
}
