using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Storages;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCore(this IServiceCollection services)
  {
    PermissionService.Register(services);
    StorageService.Register(services);
    WorldService.Register(services);
    return services.AddTransient<ICommandBus, CommandBus>();
  }
}
