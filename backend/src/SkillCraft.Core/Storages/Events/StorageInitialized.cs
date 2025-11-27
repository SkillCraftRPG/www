using Logitar.EventSourcing;

namespace SkillCraft.Core.Storages.Events;

public record StorageInitialized(UserId UserId, long AllocatedBytes) : DomainEvent;
