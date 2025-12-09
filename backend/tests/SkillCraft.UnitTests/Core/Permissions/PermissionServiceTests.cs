using Moq;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Permissions;

[Trait(Traits.Category, Categories.Unit)]
public class PermissionServiceTests
{
  private readonly CancellationToken _cancellationToken = default;

  private readonly Mock<IApplicationContext> _applicationContext = new();
  private readonly PermissionSettings _settings = new()
  {
    WorldLimit = 3
  };
  private readonly Mock<IWorldQuerier> _worldQuerier = new();

  private readonly PermissionService _permissionService;

  public PermissionServiceTests()
  {
    _permissionService = new(_applicationContext.Object, _settings, _worldQuerier.Object);
  }

  [Fact(DisplayName = "CheckAsync: it should allow the user to create a world.")]
  public async Task Given_CanCreateWorld_When_CheckAsync_Then_IsAllowedTo()
  {
    _worldQuerier.Setup(x => x.CountAsync(_cancellationToken)).ReturnsAsync(_settings.WorldLimit - 1);

    await _permissionService.CheckAsync("CreateWorld", _cancellationToken);
  }

  [Fact(DisplayName = "CheckAsync: it should throw PermissionDeniedException when the permission is not valid.")]
  public async Task Given_InvalidPermission_When_CheckAsync_Then_PermissionDeniedException()
  {
    UserId userId = UserId.NewId();
    _applicationContext.SetupGet(x => x.UserId).Returns(userId);

    _worldQuerier.Setup(x => x.CountAsync(_cancellationToken)).ReturnsAsync(_settings.WorldLimit);
    var exception = await Assert.ThrowsAsync<PermissionDeniedException>(async () => await _permissionService.CheckAsync("invalid-permission", _cancellationToken));
    Assert.Equal(userId.ToGuid(), exception.UserId);
    Assert.Equal("invalid-permission", exception.Action);
    Assert.Null(exception.Resource);
  }

  [Fact(DisplayName = "CheckAsync: it should throw PermissionDeniedException when the world limit has been reached.")]
  public async Task Given_WorldLimitReached_When_CheckAsync_Then_PermissionDeniedException()
  {
    UserId userId = UserId.NewId();
    _applicationContext.SetupGet(x => x.UserId).Returns(userId);

    _worldQuerier.Setup(x => x.CountAsync(_cancellationToken)).ReturnsAsync(_settings.WorldLimit);
    var exception = await Assert.ThrowsAsync<PermissionDeniedException>(async () => await _permissionService.CheckAsync("CreateWorld", _cancellationToken));
    Assert.Equal(userId.ToGuid(), exception.UserId);
    Assert.Equal("CreateWorld", exception.Action);
    Assert.Null(exception.Resource);
  }
}
