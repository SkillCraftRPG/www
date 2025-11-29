using SkillCraft.Core;
using SkillCraft.Infrastructure.Commands;
using SkillCraft.Settings;

namespace SkillCraft;

internal class Program
{
  static async Task Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    IConfiguration configuration = builder.Configuration;

    Startup startup = new(configuration);
    startup.ConfigureServices(builder.Services);

    WebApplication application = builder.Build();

    startup.Configure(application);

    using IServiceScope scope = application.Services.CreateScope();
    DatabaseSettings database = application.Services.GetRequiredService<DatabaseSettings>();
    if (database.ApplyMigrations)
    {
      MigrateDatabaseCommand command = new();
      ICommandHandler<MigrateDatabaseCommand> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MigrateDatabaseCommand>>();
      await handler.HandleAsync(command);
    }

    application.Run();
  }
}
