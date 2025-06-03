using Krakenar.EntityFrameworkCore.Relational;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.EntityFrameworkCore;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCore(this IServiceCollection services)
  {
    return services.AddKrakenarEntityFrameworkCoreRelational();
  }
}
