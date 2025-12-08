using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldCreated(UserId UserId, Slug Slug, Name Name) : DomainEvent;
