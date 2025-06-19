using Krakenar.Core;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.EntityFrameworkCore.Handlers;

namespace SkillCraft.EntityFrameworkCore;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCore(this IServiceCollection services)
  {
    return services
      .AddEventHandlers()
      .AddKrakenarEntityFrameworkCoreRelational()
      .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    return services
      .AddScoped<IEventHandler<ContentLocalePublished>, RuleContentEvents>()
      .AddScoped<IEventHandler<ContentLocaleUnpublished>, RuleContentEvents>();
  }
}
