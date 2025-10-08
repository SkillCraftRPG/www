using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Rules.Extractor.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractStatisticsTask : ExtractionTask
{
  public override string? Description => "Extracts the Statistic rules.";
}

internal class ExtractStatisticsTaskHandler : ICommandHandler<ExtractStatisticsTask, TaskResult>
{
  private const string Path = @"output\statistics.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<StatisticEntity> _statistics;
  private readonly ILogger<ExtractStatisticsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractStatisticsTaskHandler(RulesContext context, ILogger<ExtractStatisticsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _statistics = context.Statistics;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractStatisticsTask command, CancellationToken cancellationToken)
  {
    StatisticEntity[] entities = await _statistics.AsNoTracking()
      .Include(x => x.Attribute)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Statistics} statistic(s) from database.", entities.Length);

    List<StatisticDto> statistics = new(capacity: entities.Length);
    foreach (StatisticEntity entity in entities)
    {
      statistics.Add(ExtractionMapper.ToStatistic(entity));
    }

    string json = _serializer.Serialize(statistics);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Statistics} statistic(s) into '{Path}'.", statistics.Count, Path);

    return new TaskResult();
  }
}
