namespace SkillCraft.Core.Permissions;

public interface IPermissionService
{
  Task CheckAsync(string action, CancellationToken cancellationToken = default);
}

internal class PermissionService : IPermissionService
{
  public Task CheckAsync(string action, CancellationToken cancellationToken) => Task.CompletedTask; // TODO(fpion): implement
}
