using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishCustomizationCommand(CustomizationKind Kind, ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale)
  : ICommand<CommandResult>;

internal class PublishCustomizationCommandHandler : ICommandHandler<PublishCustomizationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishCustomizationCommandHandler> _logger;

  public PublishCustomizationCommandHandler(RulesContext context, ILogger<PublishCustomizationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishCustomizationCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    CustomizationEntity? customization = await _context.Customizations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (customization is null)
    {
      customization = new CustomizationEntity(command.Kind, command.Event);
      _context.Customizations.Add(customization);
    }

    customization.Slug = locale.GetString(GetSlugId(customization));
    customization.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    customization.Summary = locale.TryGetString(GetSummaryId(customization));
    customization.MetaDescription = locale.Description?.ToMetaDescription();
    customization.Description = locale.TryGetString(GetHtmlContentId(customization));

    customization.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The customization '{Customization}' has been published.", customization);

    return new CommandResult();
  }

  private static Guid GetHtmlContentId(CustomizationEntity customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.HtmlContent,
    CustomizationKind.Gift => Gifts.HtmlContent,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
  private static Guid GetSlugId(CustomizationEntity customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.Slug,
    CustomizationKind.Gift => Gifts.Slug,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
  private static Guid GetSummaryId(CustomizationEntity customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.Summary,
    CustomizationKind.Gift => Gifts.Summary,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
}
