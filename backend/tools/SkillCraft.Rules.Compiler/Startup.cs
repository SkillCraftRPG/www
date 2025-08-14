using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Tasks;

namespace SkillCraft.Rules.Compiler;

internal class Startup
{
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddHostedService<RuleCompiler>();

    services.AddTransient<ICommandBus, CommandBus>();
    services.AddTransient<ICommandHandler<CompileAttributes>, CompileAttributesHandler>();
    services.AddTransient<ICommandHandler<CompileCustomizations>, CompileCustomizationsHandler>();
    services.AddTransient<ICommandHandler<CompileSkills>, CompileSkillsHandler>();
    services.AddTransient<ICommandHandler<CompileTalents>, CompileTalentsHandler>();
  }
}
