using Krakenar.Core;
using SkillCraft.Rules.Extractor.Tasks;

namespace SkillCraft.Rules.Extractor;

public class RuleExtractor : BackgroundService
{
  private const string GenericErrorMessage = "An unhanded exception occurred.";

  private readonly IHostApplicationLifetime _hostApplicationLifetime;
  private readonly ILogger<RuleExtractor> _logger;
  private readonly IServiceProvider _serviceProvider;

  private ICommandBus? _commandBus = null;
  private ICommandBus CommandBus => _commandBus ?? throw new InvalidOperationException("The command bus has not been initialized.");

  private LogLevel _result = LogLevel.Information; // NOTE(fpion): "Information" means success.

  public RuleExtractor(IHostApplicationLifetime hostApplicationLifetime, ILogger<RuleExtractor> logger, IServiceProvider serviceProvider)
  {
    _hostApplicationLifetime = hostApplicationLifetime;
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    Stopwatch chrono = Stopwatch.StartNew();
    _logger.LogInformation("Worker executing at {Timestamp}.", DateTimeOffset.Now);

    using IServiceScope scope = _serviceProvider.CreateScope();
    _commandBus = scope.ServiceProvider.GetRequiredService<ICommandBus>();

    try
    {
      Directory.CreateDirectory("output");

      // NOTE(fpion): the order of these tasks matter.
      await ExecuteAsync(new ExtractAttributesTask(), cancellationToken);
      await ExecuteAsync(new ExtractStatisticsTask(), cancellationToken);
      await ExecuteAsync(new ExtractSkillsTask(), cancellationToken);
      await ExecuteAsync(new ExtractCustomizationsTask(), cancellationToken);
      await ExecuteAsync(new ExtractCastesTask(), cancellationToken);
      await ExecuteAsync(new ExtractEducationsTask(), cancellationToken);
      await ExecuteAsync(new ExtractTalentsTask(), cancellationToken);
      await ExecuteAsync(new ExtractSpecializationsTask(), cancellationToken);
      await ExecuteAsync(new ExtractSpellsTask(), cancellationToken);
    }
    catch (Exception exception)
    {
      _logger.LogError(exception, GenericErrorMessage);
      _result = LogLevel.Error;

      Environment.ExitCode = exception.HResult;
    }
    finally
    {
      chrono.Stop();

      long seconds = chrono.ElapsedMilliseconds / 1000;
      string secondText = seconds <= 1 ? "second" : "seconds";
      switch (_result)
      {
        case LogLevel.Error:
          _logger.LogError("Rule extraction failed after {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
        case LogLevel.Warning:
          _logger.LogWarning("Rule extraction completed with warnings in {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
        default:
          _logger.LogInformation("Rule extraction succeeded in {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
      }

      _hostApplicationLifetime.StopApplication();
    }
  }

  private async Task ExecuteAsync(ExtractionTask task, CancellationToken cancellationToken)
  {
    await ExecuteAsync(task, continueOnError: false, cancellationToken);
  }
  private async Task ExecuteAsync(ExtractionTask task, bool continueOnError, CancellationToken cancellationToken)
  {
    bool hasFailed = false;
    try
    {
      await CommandBus.ExecuteAsync(task, cancellationToken);
    }
    catch (Exception exception)
    {
      if (continueOnError)
      {
        _logger.LogWarning(exception, GenericErrorMessage);
        hasFailed = true;
      }
      else
      {
        throw;
      }
    }
    finally
    {
      task.Complete();

      LogLevel result = LogLevel.Information;
      if (hasFailed)
      {
        _result = LogLevel.Warning;
        result = LogLevel.Warning;
      }

      int milliseconds = task.Duration?.Milliseconds ?? 0;
      int seconds = milliseconds / 1000;
      string secondText = seconds <= 1 ? "second" : "seconds";
      _logger.Log(result, "Task '{Name}' succeeded in {Elapsed}ms ({Seconds} {SecondText}).", task.Name, milliseconds, seconds, secondText);
    }
  }
}
