using Moq;

namespace SkillCraft.Core.Worlds;

[Trait(Traits.Category, Categories.Unit)]
public class WorldManagerTests
{
  private readonly CancellationToken _cancellationToken = default;

  private readonly Mock<IWorldQuerier> _worldQuerier = new();
  private readonly Mock<IWorldRepository> _worldRepository = new();

  private readonly WorldManager _worldManager;

  public WorldManagerTests()
  {
    _worldManager = new(_worldQuerier.Object, _worldRepository.Object);
  }

  [Fact(DisplayName = "SaveAsync: it should not check for slug unicity when it has not changed.")]
  public async Task Given_NotCreated_When_SaveAsync_Then_SlugNotChecked()
  {
    World world = new(UserId.NewId(), new Slug("test"), new Name("World"));
    world.ClearChanges();

    await _worldManager.SaveAsync(world, _cancellationToken);

    _worldRepository.Verify(x => x.SaveAsync(world, _cancellationToken), Times.Once());
    _worldQuerier.Verify(x => x.FindIdAsync(It.IsAny<Slug>(), It.IsAny<CancellationToken>()), Times.Never());
  }

  [Fact(DisplayName = "SaveAsync: it should throw SlugAlreadyUsedException when the slug is already used.")]
  public async Task Given_SlugAlreadyUsed_When_SaveAsync_Then_SlugAlreadyUsedException()
  {
    World world = new(UserId.NewId(), new Slug("test"), new Name("World"));
    WorldId conflictId = WorldId.NewId();
    _worldQuerier.Setup(x => x.FindIdAsync(world.Slug, _cancellationToken)).ReturnsAsync(conflictId);

    var exception = await Assert.ThrowsAsync<SlugAlreadyUsedException>(async () => await _worldManager.SaveAsync(world, _cancellationToken));
    Assert.Equal("World", exception.Type);
    Assert.Equal(world.Slug.Value, exception.Slug);
    Assert.Equal(world.Id.ToGuid(), exception.Id);
    Assert.Equal(conflictId.ToGuid(), exception.ConflictId);
  }
}
