namespace SkillCraft.Rules.Compiler.Commands;

public interface ICommandBus
{
  Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
  Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>;
}

internal class CommandBus : ICommandBus
{
  private readonly IServiceProvider _serviceProvider;

  public CommandBus(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public async Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
  {
    Type commandType = command.GetType();
    IEnumerable<object?> handlers = _serviceProvider.GetServices(typeof(ICommandHandler<>).MakeGenericType(commandType));
    int count = handlers.Count();
    if (count != 1)
    {
      throw new InvalidOperationException($"Exactly 1 command handler was expected, but {(count < 1 ? "none was" : $"{count} were")} found for command type '{command.GetType()}'.");
    }
    object handler = handlers.Single() ?? throw new InvalidOperationException($"The command handler cannot be null for command type '{commandType}'.");

    Type[] parameterTypes = [commandType, typeof(CancellationToken)];
    MethodInfo handle = handler.GetType().GetMethod("HandleAsync", parameterTypes)
      ?? throw new NotImplementedException($"The HandleAsync method was not found on handler for command type '{commandType}'.");

    object[] parameters = [command, cancellationToken];
    await (Task)handle.Invoke(handler, parameters)!;
  }

  public async Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResult>
  {
    Type commandType = command.GetType();
    IEnumerable<object?> handlers = _serviceProvider.GetServices(typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult)));
    int count = handlers.Count();
    if (count != 1)
    {
      throw new InvalidOperationException($"Exactly 1 command handler was expected, but {(count < 1 ? "none was" : $"{count} were")} found for command type '{command.GetType()}'.");
    }
    object handler = handlers.Single() ?? throw new InvalidOperationException($"The command handler cannot be null for command type '{commandType}'.");

    Type[] parameterTypes = [commandType, typeof(CancellationToken)];
    MethodInfo handle = handler.GetType().GetMethod("HandleAsync", parameterTypes)
      ?? throw new NotImplementedException($"The HandleAsync method was not found on handler for command type '{commandType}'.");

    object[] parameters = [command, cancellationToken];
    return await (Task<TResult>)handle.Invoke(handler, parameters)!;
  }
}
