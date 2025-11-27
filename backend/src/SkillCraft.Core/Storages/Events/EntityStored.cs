using Logitar.EventSourcing;

namespace SkillCraft.Core.Storages.Events;

public record EntityStored(string Key, long Size) : DomainEvent;
