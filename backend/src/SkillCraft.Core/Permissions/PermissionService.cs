using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Permissions;

public interface IPermissionService
{
  Task CheckAsync(ActionKind action, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, CancellationToken cancellationToken = default);
  Task CheckAsync(ActionKind action, object? resource, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, object? resource, CancellationToken cancellationToken = default);
}

internal class PermissionService : IPermissionService
{
  public static void Register(IServiceCollection services)
  {
    services.AddSingleton(serviceProvider => PermissionSettings.Initialize(serviceProvider.GetRequiredService<IConfiguration>()));
    services.AddTransient<IPermissionService, PermissionService>();
  }

  private readonly IApplicationContext _applicationContext;
  private readonly PermissionSettings _settings;
  private readonly IWorldQuerier _worldQuerier;

  public PermissionService(IApplicationContext applicationContext, PermissionSettings settings, IWorldQuerier worldQuerier)
  {
    _applicationContext = applicationContext;
    _settings = settings;
    _worldQuerier = worldQuerier;
  }

  public async Task CheckAsync(ActionKind action, CancellationToken cancellationToken) => await CheckAsync(action, instance: null, cancellationToken);
  public async Task CheckAsync(string action, CancellationToken cancellationToken) => await CheckAsync(action, instance: null, cancellationToken);
  public async Task CheckAsync(ActionKind action, object? instance, CancellationToken cancellationToken) => await CheckAsync(action.ToString(), instance, cancellationToken);
  public async Task CheckAsync(string action, object? instance, CancellationToken cancellationToken)
  {
    bool isAllowed = false;
    Resource? resource = null;

    if (instance is null)
    {
      isAllowed = await IsAllowedAsync(action, cancellationToken);
    }

    if (!isAllowed)
    {
      throw new PermissionDeniedException(_applicationContext.UserId, action, resource);
    }
  }

  private async Task<bool> IsAllowedAsync(string action, CancellationToken cancellationToken)
  {
    if (action != "CreateWorld")
    {
      return false;
    }

    int count = await _worldQuerier.CountAsync(cancellationToken);
    return count < _settings.WorldLimit;
  }
}
