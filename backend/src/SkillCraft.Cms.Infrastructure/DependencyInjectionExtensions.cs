using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure;
using Krakenar.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Infrastructure.Handlers;

namespace SkillCraft.Cms.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsInfrastructure(this IServiceCollection services)
  {
    ContentMaterializationEvents.Register(services);

    return services
      .AddKrakenarInfrastructure()
      .AddKrakenarEntityFrameworkCoreRelational()
      .AddTransient<ICommandHandler<MigrateDatabase>, MigrateDatabaseCommandHandler>();
  }
}
