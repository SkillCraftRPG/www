using Krakenar.Core;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Core.Progress;

namespace SkillCraft.Cms.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsCore(this IServiceCollection services)
  {
    ProgressService.Register(services);
    return services.AddKrakenarCore();
  }
}
