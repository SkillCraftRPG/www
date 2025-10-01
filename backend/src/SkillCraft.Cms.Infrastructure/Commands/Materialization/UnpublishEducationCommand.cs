using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record UnpublishEducationCommand(ContentLocaleUnpublished Event) : ICommand<CommandResult>;

internal class UnpublishEducationCommandHandler : ICommandHandler<UnpublishEducationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<UnpublishEducationCommandHandler> _logger;

  public UnpublishEducationCommandHandler(RulesContext context, ILogger<UnpublishEducationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(UnpublishEducationCommand command, CancellationToken cancellationToken)
  {
    ContentLocaleUnpublished @event = command.Event;
    string streamId = @event.StreamId.Value;
    EducationEntity? education = await _context.Educations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (education is null)
    {
      _logger.LogWarning("The education 'StreamId={StreamId}' was not found.", streamId);
    }
    else
    {
      education.Unpublish(@event);

      await _context.SaveChangesAsync(cancellationToken);
      _logger.LogInformation("The education 'StreamId={StreamId}' has been unpublished.", streamId);
    }

    return new CommandResult();
  }
}
