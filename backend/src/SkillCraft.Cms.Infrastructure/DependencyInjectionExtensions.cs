using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure;
using Krakenar.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Cms.Core.Skills;
using SkillCraft.Cms.Core.Specializations;
using SkillCraft.Cms.Core.Statistics;
using SkillCraft.Cms.Core.Talents;
using SkillCraft.Cms.Infrastructure.Handlers;
using SkillCraft.Cms.Infrastructure.Queriers;

namespace SkillCraft.Cms.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsInfrastructure(this IServiceCollection services)
  {
    ContentMaterializationEvents.Register(services);

    return services
      .AddKrakenarInfrastructure()
      .AddKrakenarEntityFrameworkCoreRelational()
      .AddSkillCraftCmsQueriers()
      .AddTransient<ICommandHandler<MigrateDatabase>, MigrateDatabaseCommandHandler>();
  }

  private static IServiceCollection AddSkillCraftCmsQueriers(this IServiceCollection services)
  {
    return services
      .AddScoped<IAttributeQuerier, AttributeQuerier>()
      .AddScoped<ISkillQuerier, SkillQuerier>()
      .AddScoped<ISpecializationQuerier, SpecializationQuerier>()
      .AddScoped<IStatisticQuerier, StatisticQuerier>()
      .AddScoped<ITalentQuerier, TalentQuerier>();
  }
}
