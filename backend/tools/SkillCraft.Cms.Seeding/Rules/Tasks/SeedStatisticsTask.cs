using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Statistics;
using SkillCraft.Cms.Core.Statistics.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedStatisticsTask : SeedingTask
{
  public override string? Description => "Seeds the Statistics contents.";
}

internal class SeedStatisticsTaskHandler : ICommandHandler<SeedStatisticsTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly ILogger<SeedStatisticsTaskHandler> _logger;
  private readonly IStatisticQuerier _statisticQuerier;

  public SeedStatisticsTaskHandler(
    IContentService contentService,
    DefaultSettings defaults,
    ILogger<SeedStatisticsTaskHandler> logger,
    IStatisticQuerier statisticQuerier)
  {
    _contentService = contentService;
    _defaults = defaults;
    _logger = logger;
    _statisticQuerier = statisticQuerier;
  }

  public async Task<TaskResult> HandleAsync(SeedStatisticsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/statistics.json", Encoding.UTF8, cancellationToken);
    StatisticDto[] entities = SeedingSerializer.Deserialize<StatisticDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Statistics} statistic(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<StatisticModel> statistics = await _statisticQuerier.SearchAsync(new SearchStatisticsPayload(), cancellationToken);
      Dictionary<Guid, StatisticModel> statisticsById = statistics.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Statistics} statistic(s) from database.", statisticsById.Count);

      foreach (StatisticDto entity in entities)
      {
        _ = statisticsById.TryGetValue(entity.Id, out StatisticModel? statistic);
        if (statistic is null || HasChanges(statistic, entity))
        {
          Content content;
          if (statistic is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Statistics.ContentTypeId.ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            payload.FieldValues.AddRange(GetInvariantFieldValues(entity));
            payload.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.CreateAsync(payload, cancellationToken);
          }
          else
          {
            SaveContentLocalePayload invariant = new()
            {
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name
            };
            invariant.FieldValues.AddRange(GetInvariantFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The statistic content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The statistic content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Statistic '{Statistic}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Statistic '{Statistic}' has no change.", statistic);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(StatisticModel statistic, StatisticDto entity) => statistic.Slug != entity.Slug
    || statistic.Name != entity.Name
    || statistic.Attribute.Id != entity.Attribute.Id
    || statistic.Value != entity.Value
    || statistic.Summary != entity.Summary
    || statistic.MetaDescription != entity.MetaDescription
    || statistic.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(StatisticDto statistic)
  {
    List<FieldValuePayload> payloads = new(capacity: 1);

    string value = SeedingSerializer.Serialize<Guid[]>([statistic.Attribute.Id]);
    payloads.Add(new FieldValuePayload(Statistics.Attribute.ToString(), value));

    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(StatisticDto statistic)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Statistics.Slug.ToString(), statistic.Slug)
    };
    if (!string.IsNullOrWhiteSpace(statistic.Summary))
    {
      payloads.Add(new FieldValuePayload(Statistics.Summary.ToString(), statistic.Summary));
    }
    if (!string.IsNullOrWhiteSpace(statistic.Description))
    {
      payloads.Add(new FieldValuePayload(Statistics.HtmlContent.ToString(), statistic.Description));
    }
    return payloads.AsReadOnly();
  }
}
