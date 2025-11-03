using Logitar.EventSourcing.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Handlers;
using SkillCraft.Infrastructure.Queriers;
using SkillCraft.Infrastructure.Repositories;

namespace SkillCraft.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services)
  {
    return services
      .AddEventHandlers()
      .AddQueriers()
      .AddRepositories()
      .AddSingleton<IEventSerializer, EventSerializer>()
      .AddScoped<IActorService, ActorService>();
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    WorldEvents.Register(services);
    return services;
  }

  private static IServiceCollection AddQueriers(this IServiceCollection services)
  {
    return services.AddScoped<IWorldQuerier, WorldQuerier>();
  }

  private static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    return services.AddScoped<IWorldRepository, WorldRepository>();
  }
}
