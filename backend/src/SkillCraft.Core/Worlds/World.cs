using Logitar.EventSourcing;
using SkillCraft.Core.Worlds.Events;

namespace SkillCraft.Core.Worlds;

public class World : AggregateRoot
{
  private readonly WorldUpdated _updated = new();
  private bool HasUpdates => _updated.Name is not null || _updated.Description is not null;

  public new WorldId Id => new(base.Id);

  public UserId UserId { get; private set; }

  private Slug? _slug = null;
  public Slug Slug => _slug ?? throw new InvalidOperationException("The slug has not been initialized.");

  private Name? _name = null;
  public Name Name
  {
    get => _name ?? throw new InvalidOperationException("The name has not been initialized.");
    set
    {
      if (_name != value)
      {
        _name = value;
        _updated.Name = value;
      }
    }
  }
  private Description? _description = null;
  public Description? Description
  {
    get => _description;
    set
    {
      if (_description != value)
      {
        _description = value;
        _updated.Description = new Change<Description>(value);
      }
    }
  }

  public World() : base()
  {
  }

  public World(UserId userId, Slug slug, Name name, WorldId? worldId = null)
    : base((worldId ?? WorldId.NewId()).StreamId)
  {
    Raise(new WorldCreated(userId, slug, name), userId.ActorId);
  }
  protected virtual void Handle(WorldCreated @event)
  {
    UserId = @event.UserId;

    _slug = @event.Slug;

    _name = @event.Name;
  }

  public void Delete(UserId userId)
  {
    if (!IsDeleted)
    {
      Raise(new WorldDeleted(), userId.ActorId);
    }
  }

  public void Update(UserId userId)
  {
    if (HasUpdates)
    {
      Raise(_updated, userId.ActorId, DateTime.Now);
    }
  }
  protected virtual void Handle(WorldUpdated @event)
  {
    if (@event.Name is not null)
    {
      _name = @event.Name;
    }
    if (@event.Description is not null)
    {
      _description = @event.Description.Value;
    }
  }

  public override string ToString() => $"{Name?.Value ?? Slug.Value} | {base.ToString()}";
}
