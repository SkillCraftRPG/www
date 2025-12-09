using Logitar;
using Logitar.CQRS;
using Logitar.EventSourcing.EntityFrameworkCore.PostgreSQL;
using Logitar.EventSourcing.EntityFrameworkCore.Relational;
using Logitar.EventSourcing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Caching;
using SkillCraft.Infrastructure.Commands;
using SkillCraft.Infrastructure.Handlers;
using SkillCraft.Infrastructure.Queriers;
using SkillCraft.Infrastructure.Repositories;

namespace SkillCraft.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("POSTGRESQLCONNSTR_SkillCraft")
      ?? configuration.GetConnectionString("PostgreSQL")?.CleanTrim()
      ?? throw new ArgumentException("The PostgreSQL connection string could not be found.", nameof(configuration));
    return services.AddSkillCraftInfrastructure(connectionString);
  }
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services, string connectionString)
  {
    ActorService.Register(services);
    CacheService.Register(services);
    return services
      .AddLogitarEventSourcingWithEntityFrameworkCoreRelational()
      .AddLogitarEventSourcingWithEntityFrameworkCorePostgreSQL(connectionString)
      .AddDbContext<GameContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("SkillCraft.Infrastructure")))
      .AddEventHandlers()
      .AddQueriers()
      .AddRepositories()
      .AddSingleton<IEventSerializer, EventSerializer>()
      .AddScoped<IEventBus, EventBus>()
      .AddTransient<ICommandHandler<MigrateDatabaseCommand, Unit>, MigrateDatabaseCommandHandler>();
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    WorldEvents.Register(services);
    return services;
  }

  private static IServiceCollection AddQueriers(this IServiceCollection services) => services.AddScoped<IWorldQuerier, WorldQuerier>();

  private static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped<IWorldRepository, WorldRepository>();
}
