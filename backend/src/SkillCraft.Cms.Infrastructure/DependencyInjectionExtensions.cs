using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure;
using Krakenar.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Cms.Core.Castes;
using SkillCraft.Cms.Core.Customizations;
using SkillCraft.Cms.Core.Educations;
using SkillCraft.Cms.Core.Lineages;
using SkillCraft.Cms.Core.Scripts;
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
      .AddScoped<ICasteQuerier, CasteQuerier>()
      .AddScoped<ICustomizationQuerier, CustomizationQuerier>()
      .AddScoped<IEducationQuerier, EducationQuerier>()
      .AddScoped<ILineageQuerier, LineageQuerier>()
      .AddScoped<IScriptQuerier, ScriptQuerier>()
      .AddScoped<ISkillQuerier, SkillQuerier>()
      .AddScoped<ISpecializationQuerier, SpecializationQuerier>()
      .AddScoped<IStatisticQuerier, StatisticQuerier>()
      .AddScoped<ITalentQuerier, TalentQuerier>();
  }
}
