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
  Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}

public interface IQuery<TResult>;

public interface IQueryBus
{
  Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
  Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
