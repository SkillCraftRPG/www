using Krakenar.Core;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCore(this IServiceCollection services)
  {
    return services.AddKrakenarCore();
  }
}
