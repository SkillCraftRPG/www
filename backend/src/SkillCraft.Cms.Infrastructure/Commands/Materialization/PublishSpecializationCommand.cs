using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishSpecializationCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishSpecializationCommandHandler : ICommandHandler<PublishSpecializationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishSpecializationCommandHandler> _logger;

  public PublishSpecializationCommandHandler(RulesContext context, ILogger<PublishSpecializationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishSpecializationCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    SpecializationEntity? specialization = await _context.Specializations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (specialization is null)
    {
      specialization = new SpecializationEntity(command.Event);
      _context.Specializations.Add(specialization);
    }

    specialization.Slug = locale.GetString(Specializations.Slug);
    specialization.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    specialization.Tier = (int)locale.GetNumber(Specializations.Tier);

    // TODO(fpion): Specializations.MandatoryTalent
    // TODO(fpion): Specializations.OptionalTalents

    specialization.Summary = locale.TryGetString(Specializations.Summary);
    specialization.Description = locale.TryGetString(Specializations.HtmlContent);

    specialization.OtherRequirements = locale.TryGetString(Specializations.OtherRequirements);
    specialization.OtherOptions = locale.TryGetString(Specializations.OtherOptions);

    // TODO(fpion): ReservedTalent

    specialization.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The specialization '{Specialization}' has been published.", specialization);

    return new CommandResult();
  }
}
