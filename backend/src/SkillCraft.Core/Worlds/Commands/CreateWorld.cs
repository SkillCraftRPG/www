using FluentValidation;
using Logitar.CQRS;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Core.Worlds.Validators;

namespace SkillCraft.Core.Worlds.Commands;

/// <exception cref="PermissionDeniedException"></exception>
/// <exception cref="ValidationException"></exception>
internal record CreateWorldCommand(CreateWorldPayload Payload, Guid? Id) : ICommand<WorldModel>;

internal class CreateWorldCommandHandler : ICommandHandler<CreateWorldCommand, WorldModel>
{
  private readonly IApplicationContext _applicationContext;
  private readonly IPermissionService _permissionService;
  private readonly IWorldManager _worldManager;
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public CreateWorldCommandHandler(
    IApplicationContext applicationContext,
    IPermissionService permissionService,
    IWorldManager worldManager,
    IWorldQuerier worldQuerier,
    IWorldRepository worldRepository)
  {
    _applicationContext = applicationContext;
    _permissionService = permissionService;
    _worldManager = worldManager;
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task<WorldModel> HandleAsync(CreateWorldCommand command, CancellationToken cancellationToken)
  {
    CreateWorldPayload payload = command.Payload;
    new CreateWorldValidator().ValidateAndThrow(payload);

    await _permissionService.CheckAsync("CreateWorld", cancellationToken);

    WorldId worldId = WorldId.NewId();
    World? world;
    if (command.Id.HasValue)
    {
      worldId = new(command.Id.Value);
      world = await _worldRepository.LoadAsync(worldId, cancellationToken);
      if (world is not null)
      {
        throw new NotImplementedException(); // TODO(fpion): 409 Conflict
      }
    }

    UserId userId = _applicationContext.UserId;
    Slug slug = new(payload.Slug);
    Name name = new(payload.Name);
    world = new(userId, slug, name, worldId)
    {
      Description = Description.TryCreate(payload.Description)
    };

    world.Update(userId);

    await _worldManager.SaveAsync(world, cancellationToken);

    return await _worldQuerier.ReadAsync(world, cancellationToken);
  }
}
