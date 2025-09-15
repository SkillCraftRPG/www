using Krakenar.Core;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Cms.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCmsCore(this IServiceCollection services)
  {
    return services.AddKrakenarCore();
  }
}
