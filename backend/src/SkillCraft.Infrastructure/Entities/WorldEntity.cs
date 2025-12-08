using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Events;
using SkillCraft.Infrastructure.GameDb;

namespace SkillCraft.Infrastructure.Entities;

internal class WorldEntity : AggregateEntity
{
  public int WorldId { get; private set; }
  public Guid Id { get; private set; }

  public Guid UserId { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; private set; } = string.Empty;
  public string? Description { get; private set; }

  public WorldEntity(WorldCreated @event) : base(@event)
  {
    Id = new WorldId(@event.StreamId).ToGuid();

    UserId = @event.UserId.ToGuid();

    Slug = @event.Slug.Value;
    Name = @event.Name.Value;
  }

  private WorldEntity() : base()
  {
  }

  public void Update(WorldUpdated @event)
  {
    base.Update(@event);

    if (@event.Name is not null)
    {
      Name = @event.Name.Value;
    }
    if (@event.Description is not null)
    {
      Description = @event.Description.Value?.Value;
    }
  }

  public override string ToString() => $"{Name ?? Slug} | {base.ToString()}";
}
