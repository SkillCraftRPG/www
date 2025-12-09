using FluentValidation;
using Moq;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds.Commands;

[Trait(Traits.Category, Categories.Unit)]
public class CreateWorldCommandHandlerTests
{
  private readonly CancellationToken _cancellationToken = default;

  private readonly Mock<IApplicationContext> _applicationContext = new();
  private readonly Mock<IPermissionService> _permissionService = new();
  private readonly Mock<IWorldManager> _worldManager = new();
  private readonly Mock<IWorldQuerier> _worldQuerier = new();
  private readonly Mock<IWorldRepository> _worldRepository = new();

  private readonly CreateWorldCommandHandler _handler;

  public CreateWorldCommandHandlerTests()
  {
    _handler = new(_applicationContext.Object, _permissionService.Object, _worldManager.Object, _worldQuerier.Object, _worldRepository.Object);
  }

  [Fact(DisplayName = "It should throw ValidationException when the payload is not valid.")]
  public async Task Given_InvalidPayload_When_HandleAsync_Then_ValidationException()
  {
    CreateWorldPayload payload = new()
    {
      Slug = "invalid!"
    };
    CreateWorldCommand command = new(payload);
    var exception = await Assert.ThrowsAsync<ValidationException>(async () => await _handler.HandleAsync(command, _cancellationToken));
    Assert.Equal(2, exception.Errors.Count());
    Assert.Contains(exception.Errors, e => e.ErrorCode == "SlugValidator" && e.PropertyName == "Slug");
    Assert.Contains(exception.Errors, e => e.ErrorCode == "NotEmptyValidator" && e.PropertyName == "Name");
  }
}
