using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Logitar.EventSourcing.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Storages;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Caching;
using SkillCraft.Infrastructure.Handlers;
using SkillCraft.Infrastructure.Queriers;
using SkillCraft.Infrastructure.Repositories;

namespace SkillCraft.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services)
  {
    ActorService.Register(services);
    CacheService.Register(services);
    return services
      .AddLogitarEventSourcingWithEntityFrameworkCoreRelational()
      .AddEventHandlers()
      .AddQueriers()
      .AddRepositories()
      .AddSingleton<IEventSerializer, EventSerializer>();
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    StorageEvents.Register(services);
    WorldEvents.Register(services);
    return services;
  }

  private static IServiceCollection AddQueriers(this IServiceCollection services)
  {
    return services.AddScoped<IWorldQuerier, WorldQuerier>();
  }

  private static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    return services
      .AddScoped<IStorageRepository, StorageRepository>()
      .AddScoped<IWorldRepository, WorldRepository>();
  }
}
