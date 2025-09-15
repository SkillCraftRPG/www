using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure;
using Krakenar.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Core.Talents;
using SkillCraft.Cms.Infrastructure.Handlers;
using SkillCraft.Cms.Infrastructure.Queriers;

namespace SkillCraft.Cms.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsInfrastructure(this IServiceCollection services)
  {
    ContentMaterializationEvents.Register(services);

    services.AddScoped<ITalentQuerier, TalentQuerier>();

    return services
      .AddKrakenarInfrastructure()
      .AddKrakenarEntityFrameworkCoreRelational()
      .AddTransient<ICommandHandler<MigrateDatabase>, MigrateDatabaseCommandHandler>();
  }
}
