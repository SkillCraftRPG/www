using Logitar.EventSourcing;

namespace SkillCraft.Core;

public interface ICommand<T>;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>;

public interface ICommandBus
{
  Task<TResult> HandleAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}

public interface IEventHandler<T> where T : IEvent
{
  Task HandleAsync(T @event, CancellationToken cancellationToken = default);
}
