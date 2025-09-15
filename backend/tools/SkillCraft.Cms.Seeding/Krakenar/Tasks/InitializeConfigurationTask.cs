using Krakenar.Core;
using Krakenar.Core.Configurations.Commands;
using SkillCraft.Cms.Seeding.Settings;

namespace SkillCraft.Cms.Seeding.Krakenar.Tasks;

internal class InitializeConfigurationTask : SeedingTask
{
  public override string? Description => "Initializes Krakenar configuration.";
  public DefaultSettings Defaults { get; }

  public InitializeConfigurationTask(DefaultSettings defaults)
  {
    Defaults = defaults;
  }
}

internal class InitializeConfigurationTaskHandler : ICommandHandler<InitializeConfigurationTask, SeedingTaskResult>
{
  private readonly ICommandHandler<InitializeConfiguration> _handler;

  public InitializeConfigurationTaskHandler(ICommandHandler<InitializeConfiguration> handler)
  {
    _handler = handler;
  }

  public async Task<SeedingTaskResult> HandleAsync(InitializeConfigurationTask task, CancellationToken cancellationToken)
  {
    DefaultSettings defaults = task.Defaults;
    InitializeConfiguration command = new(defaults.Locale, defaults.UniqueName, defaults.Password);
    await _handler.HandleAsync(command, cancellationToken);

    return new SeedingTaskResult();
  }
}
