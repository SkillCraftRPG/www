using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure.Commands;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.Cms.Infrastructure.Handlers;

internal class MigrateDatabaseCommandHandler : Krakenar.EntityFrameworkCore.Relational.Handlers.MigrateDatabaseCommandHandler
{
  private readonly RulesContext _rulesContext;

  public MigrateDatabaseCommandHandler(RulesContext rulesContext, EventContext eventContext, KrakenarContext krakenarContext)
    : base(eventContext, krakenarContext)
  {
    _rulesContext = rulesContext;
  }

  public override async Task HandleAsync(MigrateDatabase _, CancellationToken cancellationToken)
  {
    await base.HandleAsync(_, cancellationToken);

    await _rulesContext.Database.MigrateAsync(cancellationToken);
  }
}
