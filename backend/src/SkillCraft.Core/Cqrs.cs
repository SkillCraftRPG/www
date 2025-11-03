namespace SkillCraft.Core;

public interface ICommand<T>;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>;

public interface ICommandBus
{
  Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}
