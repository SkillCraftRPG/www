using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure.Commands;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Microsoft.EntityFrameworkCore;

namespace SkillCraft.Cms.Infrastructure.Handlers;

internal class MigrateDatabaseCommandHandler : Krakenar.EntityFrameworkCore.Relational.Handlers.MigrateDatabaseCommandHandler
{
  private readonly CmsContext _cmsContext;

  public MigrateDatabaseCommandHandler(CmsContext cmsContext, EventContext eventContext, KrakenarContext krakenarContext)
    : base(eventContext, krakenarContext)
  {
    _cmsContext = cmsContext;
  }

  public override async Task HandleAsync(MigrateDatabase _, CancellationToken cancellationToken)
  {
    await base.HandleAsync(_, cancellationToken);

    await _cmsContext.Database.MigrateAsync(cancellationToken);
  }
}
