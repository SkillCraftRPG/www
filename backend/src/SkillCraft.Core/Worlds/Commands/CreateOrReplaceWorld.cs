using FluentValidation;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Core.Worlds.Validators;

namespace SkillCraft.Core.Worlds.Commands;

/// <exception cref="PermissionDeniedException"></exception>
/// <exception cref="ValidationException"></exception>
internal record CreateOrReplaceWorldCommand(CreateOrReplaceWorldPayload Payload, Guid? Id) : ICommand<CreateOrReplaceWorldResult>;

internal class CreateOrReplaceWorldCommandHandler : ICommandHandler<CreateOrReplaceWorldCommand, CreateOrReplaceWorldResult>
{
  private readonly IContext _context;
  private readonly IPermissionService _permissionService;
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public CreateOrReplaceWorldCommandHandler(IContext context, IPermissionService permissionService, IWorldQuerier worldQuerier, IWorldRepository worldRepository)
  {
    _context = context;
    _permissionService = permissionService;
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task<CreateOrReplaceWorldResult> HandleAsync(CreateOrReplaceWorldCommand command, CancellationToken cancellationToken)
  {
    CreateOrReplaceWorldPayload payload = command.Payload;
    new CreateOrReplaceWorldValidator().ValidateAndThrow(payload);

    WorldId worldId = WorldId.NewId();
    World? world = null;
    if (command.Id.HasValue)
    {
      worldId = new WorldId(command.Id.Value);
      world = await _worldRepository.LoadAsync(worldId, cancellationToken);
    }

    UserId userId = _context.UserId;
    Name name = new(payload.Name);

    bool created = false;
    if (world is null)
    {
      await _permissionService.CheckAsync("CreateWorld", cancellationToken);

      world = new World(name, userId, worldId);
    }
    else
    {
      await _permissionService.CheckAsync("Update", world, cancellationToken);

      world.Name = name;
    }

    world.Description = Description.TryCreate(payload.Description);

    world.Update(userId);
    // TODO(fpion): ensure enough storage
    await _worldRepository.SaveAsync(world, cancellationToken);
    // TODO(fpion): update storage

    WorldModel model = await _worldQuerier.ReadAsync(world, cancellationToken);
    return new CreateOrReplaceWorldResult(model, created);
  }
}
