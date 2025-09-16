using Krakenar.Core;
using Krakenar.Infrastructure.Commands;

namespace SkillCraft.Cms.Seeding.Krakenar.Tasks;

internal class MigrateDatabaseTask : SeedingTask
{
  public override string? Description => "Migrates Krakenar database.";
}

internal class MigrateDatabaseTaskHandler : ICommandHandler<MigrateDatabaseTask, SeedingTaskResult>
{
  private readonly ICommandHandler<MigrateDatabase> _handler;

  public MigrateDatabaseTaskHandler(ICommandHandler<MigrateDatabase> handler)
  {
    _handler = handler;
  }

  public async Task<SeedingTaskResult> HandleAsync(MigrateDatabaseTask _, CancellationToken cancellationToken)
  {
    MigrateDatabase command = new();
    await _handler.HandleAsync(command, cancellationToken);

    return new SeedingTaskResult();
  }
}
