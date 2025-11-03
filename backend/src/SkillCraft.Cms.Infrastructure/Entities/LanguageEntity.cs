using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.EventSourcing;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class LanguageEntity : AggregateEntity
{
  public int LanguageId { get; private set; }
  public Guid Id { get; private set; }

  public bool IsPublished { get; private set; }

  public string Slug { get; set; } = string.Empty;
  public string SlugNormalized
  {
    get => Helper.Normalize(Slug);
    private set { }
  }
  public string Name { get; set; } = string.Empty;

  public ScriptEntity? Script { get; private set; }
  public int? ScriptId { get; private set; }
  public Guid? ScriptUid { get; private set; }

  public string? TypicalSpeakers { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public List<LineageLanguageEntity> Lineages { get; private set; } = [];

  public LanguageEntity(ContentLocalePublished @event) : base(@event)
  {
    Id = new ContentId(@event.StreamId).EntityId;

    IsPublished = true;
  }

  private LanguageEntity() : base()
  {
  }

  public override IReadOnlyCollection<ActorId> GetActorIds()
  {
    List<ActorId> actorIds = new(base.GetActorIds());
    if (Script is not null)
    {
      actorIds.AddRange(Script.GetActorIds());
    }
    return actorIds.AsReadOnly();
  }

  public void Publish(ContentLocalePublished @event)
  {
    Update(@event);

    IsPublished = true;
  }

  public void SetScript(ScriptEntity? script)
  {
    Script = script;
    ScriptId = script?.ScriptId;
    ScriptUid = script?.Id;
  }

  public void Unpublish(ContentLocaleUnpublished @event)
  {
    Update(@event);

    IsPublished = false;
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
