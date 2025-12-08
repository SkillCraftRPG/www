namespace SkillCraft.Core;

public interface ICommand : ICommand<Unit>;
public interface ICommand<TResult>;

public interface ICommandBus
{
  Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<ICommand>
{
  Task HandleAsync(ICommand command, CancellationToken cancellationToken = default);
}
public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
  Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public readonly struct Unit;
