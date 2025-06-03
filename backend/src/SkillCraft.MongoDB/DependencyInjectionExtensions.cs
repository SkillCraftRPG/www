using Krakenar.Core;
using Krakenar.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.MongoDB;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftMongoDB(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("MONGOCONNSTR_SkillCraft", configuration.GetConnectionString("MongoDB"));
    MongoDBSettings settings = MongoDBSettings.Initialize(configuration);
    return services.AddKrakenarMongoDB(connectionString, settings);
  }
  public static IServiceCollection AddSkillCraftMongoDB(this IServiceCollection services, string? connectionString, MongoDBSettings settings)
  {
    return services.AddKrakenarMongoDB(connectionString, settings);
  }
}
