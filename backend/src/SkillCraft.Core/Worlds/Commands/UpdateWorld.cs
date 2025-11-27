using FluentValidation;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Storages;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Core.Worlds.Validators;

namespace SkillCraft.Core.Worlds.Commands;

/// <exception cref="NotEnoughAvailableStorageException"></exception>
/// <exception cref="PermissionDeniedException"></exception>
/// <exception cref="ValidationException"></exception>
internal record UpdateWorldCommand(Guid Id, UpdateWorldPayload Payload) : ICommand<WorldModel?>;

internal class UpdateWorldCommandHandler : ICommandHandler<UpdateWorldCommand, WorldModel?>
{
  private readonly IContext _context;
  private readonly IPermissionService _permissionService;
  private readonly IStorageService _storageService;
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public UpdateWorldCommandHandler(
    IContext context,
    IPermissionService permissionService,
    IStorageService storageService,
    IWorldQuerier worldQuerier,
    IWorldRepository worldRepository)
  {
    _context = context;
    _permissionService = permissionService;
    _storageService = storageService;
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task<WorldModel?> HandleAsync(UpdateWorldCommand command, CancellationToken cancellationToken)
  {
    UpdateWorldPayload payload = command.Payload;
    new UpdateWorldValidator().ValidateAndThrow(payload);

    WorldId worldId = new(command.Id);
    World? world = await _worldRepository.LoadAsync(worldId, cancellationToken);
    if (world is null)
    {
      return null;
    }
    await _permissionService.CheckAsync("Update", world, cancellationToken);

    if (!string.IsNullOrWhiteSpace(payload.Name))
    {
      world.Name = new Name(payload.Name);
    }
    if (payload.Description is not null)
    {
      world.Description = Description.TryCreate(payload.Description.Value);
    }

    world.Update(_context.UserId);

    await _storageService.EnsureAvailableAsync(world, cancellationToken);
    await _worldRepository.SaveAsync(world, cancellationToken);
    await _storageService.UpdateAsync(world, cancellationToken);

    return await _worldQuerier.ReadAsync(world, cancellationToken);
  }
}
