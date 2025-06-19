using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.Handlers;
using Krakenar.Infrastructure.Commands;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.EntityFrameworkCore.Handlers;

internal class MigrateSkillCraftDatabaseCommandHandler : MigrateDatabaseCommandHandler
{
  private readonly RuleContext _rules;

  public MigrateSkillCraftDatabaseCommandHandler(EventContext events, KrakenarContext krakenar, RuleContext rules) : base(events, krakenar)
  {
    _rules = rules;
  }

  public override async Task HandleAsync(MigrateDatabase command, CancellationToken cancellationToken)
  {
    await base.HandleAsync(command, cancellationToken);

    await _rules.Database.MigrateAsync(cancellationToken);
  }
}
