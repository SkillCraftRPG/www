using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Rules;
using SkillCraft.EntityFrameworkCore.Handlers;
using SkillCraft.EntityFrameworkCore.Queriers.Rules;

namespace SkillCraft.EntityFrameworkCore;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCore(this IServiceCollection services)
  {
    return services
      .AddEventHandlers()
      .AddKrakenarEntityFrameworkCoreRelational()
      .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
      .AddRuleQueriers()
      .AddScoped<ICommandHandler<MigrateDatabase>, MigrateSkillCraftDatabaseCommandHandler>();
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    return services
      .AddScoped<IEventHandler<ContentLocalePublished>, RuleContentEvents>()
      .AddScoped<IEventHandler<ContentLocaleUnpublished>, RuleContentEvents>();
  }

  private static IServiceCollection AddRuleQueriers(this IServiceCollection services)
  {
    return services
      .AddScoped<IAttributeQuerier, AttributeQuerier>()
      .AddScoped<ISkillQuerier, SkillQuerier>()
      .AddScoped<ITalentQuerier, TalentQuerier>();
  }
}
