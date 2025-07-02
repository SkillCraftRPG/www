using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedStatisticsTask : SeedingTask
{
  public override string? Description => "Seeds the statistic contents into Krakenar.";
  public string Language { get; }

  public SeedStatisticsTask(string language)
  {
    Language = language;
  }
}

internal class SeedStatisticsTaskHandler : INotificationHandler<SeedStatisticsTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedStatisticsTaskHandler> _logger;

  public SeedStatisticsTaskHandler(IContentService contentService, ILogger<SeedStatisticsTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedStatisticsTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/statistics.json", Encoding.UTF8, cancellationToken);
    IEnumerable<StatisticPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<StatisticPayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Statistics.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (StatisticPayload statistic in payloads)
      {
        string attribute = JsonSerializer.Serialize<Guid[]>([statistic.AttributeId]);

        Content content;
        if (existingIds.Contains(statistic.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = statistic.Value.ToString(),
            DisplayName = statistic.Name,
            Description = statistic.Notes
          };
          invariant.FieldValues.Add(new FieldValuePayload(Statistics.Attribute.ToString(), attribute));
          _ = await _contentService.SaveLocaleAsync(statistic.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = statistic.Value.ToString(),
            DisplayName = statistic.Name,
            Description = statistic.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Statistics.Slug.ToString(), statistic.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Statistics.Summary.ToString(), statistic.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Statistics.Description.ToString(), statistic.Description ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(statistic.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={statistic.Id}' was not found.");

          _logger.LogInformation("The statistic '{Statistic}' was updated.", statistic.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = statistic.Id,
            ContentType = Statistics.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = statistic.Value.ToString(),
            DisplayName = statistic.Name,
            Description = statistic.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Statistics.Attribute.ToString(), attribute));
          payload.FieldValues.Add(new FieldValuePayload(Statistics.Slug.ToString(), statistic.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Statistics.Summary.ToString(), statistic.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Statistics.Description.ToString(), statistic.Description ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The statistic '{Statistic}' was created.", statistic.Name);
        }

        _ = await _contentService.PublishAsync(statistic.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(statistic.Id, task.Language, cancellationToken);
        _logger.LogInformation("The statistic '{Statistic}' was published.", statistic.Name);
      }
    }
  }
}
