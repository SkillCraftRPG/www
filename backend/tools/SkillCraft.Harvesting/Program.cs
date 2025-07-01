namespace SkillCraft.Harvesting;

internal static class Program
{
  public static void Main(string[] args)
  {
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    IConfiguration configuration = builder.Configuration;

    Startup startup = new(configuration);
    startup.ConfigureService(builder.Services);

    IHost host = builder.Build();
    host.Run();
  }
}
