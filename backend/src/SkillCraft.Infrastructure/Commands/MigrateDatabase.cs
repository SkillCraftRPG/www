using Logitar.CQRS;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.Infrastructure.Commands;

public record MigrateDatabaseCommand : ICommand;

internal class MigrateDatabaseCommandHandler : ICommandHandler<MigrateDatabaseCommand, Unit>
{
  private readonly EventContext _eventContext;
  private readonly GameContext _gameContext;

  public MigrateDatabaseCommandHandler(EventContext eventContext, GameContext gameContext)
  {
    _eventContext = eventContext;
    _gameContext = gameContext;
  }

  public async Task<Unit> HandleAsync(MigrateDatabaseCommand command, CancellationToken cancellationToken)
  {
    await _eventContext.Database.MigrateAsync(cancellationToken);
    await _gameContext.Database.MigrateAsync(cancellationToken);
    return Unit.Value;
  }
}
