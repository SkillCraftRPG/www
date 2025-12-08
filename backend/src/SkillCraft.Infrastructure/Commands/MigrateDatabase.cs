using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core;

namespace SkillCraft.Infrastructure.Commands;

public record MigrateDatabaseCommand : ICommand;

internal class MigrateDatabaseCommandHandler : ICommandHandler<MigrateDatabaseCommand>
{
  private readonly EventContext _eventContext;
  private readonly GameContext _gameContext;

  public MigrateDatabaseCommandHandler(EventContext eventContext, GameContext gameContext)
  {
    _eventContext = eventContext;
    _gameContext = gameContext;
  }

  public async Task HandleAsync(MigrateDatabaseCommand command, CancellationToken cancellationToken)
  {
    await _eventContext.Database.MigrateAsync(cancellationToken);
    await _gameContext.Database.MigrateAsync(cancellationToken);
  }
}
