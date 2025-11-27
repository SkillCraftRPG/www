namespace SkillCraft.Core;

public interface ICommand;
public interface ICommand<TResult>;

public interface ICommandBus
{
  Task ExecuteAsync(ICommand command, CancellationToken cancellationToken = default);
  Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
  Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
  Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface IEventHandler<TEvent>
{
  Task HandAsync(TEvent @event, CancellationToken cancellationToken = default);
}
