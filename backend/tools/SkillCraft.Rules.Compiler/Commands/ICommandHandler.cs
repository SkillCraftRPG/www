namespace SkillCraft.Rules.Compiler.Commands;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
  Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
  Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
