using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileStatistics : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles statistic rules.";
}

internal class CompileStatisticsHandler : ICommandHandler<CompileStatistics>
{
  private readonly ILogger<CompileStatisticsHandler> _logger;

  public CompileStatisticsHandler(ILogger<CompileStatisticsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileStatistics command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("data\\output\\attributes.json", Constants.Encoding, cancellationToken);
    IReadOnlyCollection<AttributeModel> attributes = JsonSerializer.Deserialize<IReadOnlyCollection<AttributeModel>>(json, Constants.SerializerOptions) ?? [];
    Dictionary<Guid, AttributeModel> attributesById = attributes.ToDictionary(x => x.Id, x => x);
    Dictionary<string, AttributeModel> attributesBySlug = attributes.ToDictionary(x => Normalize(x.Slug), x => x);

    IReadOnlyCollection<StatisticPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, StatisticPayload[]> statisticsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, StatisticPayload[]> statisticsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Statistic> statistics = [];
    StatisticValidator validator = new();
    foreach (StatisticPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Statistic 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (statisticsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Statistic ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (statisticsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Statistic Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Statistic statistic = new()
      {
        Id = payload.Id,
        Slug = slug,
        Value = payload.Value,
        Name = payload.Name.Trim(),
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim().Replace("\\n", "\n"),
        Notes = payload.Notes?.CleanTrim()?.Replace("\\n", "\n")
      };

      AttributeModel? attribute = Find(payload.Attribute, attributesById, attributesBySlug);
      if (attribute is null)
      {
        _logger.LogWarning("Attribute for statistic 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", statistic.Id, statistic.Name, payload.Attribute);
        continue;
      }
      else
      {
        statistic.AttributeId = attribute.Id;
      }

      statistics.Add(statistic);
    }

    await LoadAsync(statistics, cancellationToken);

    _logger.LogInformation("Compiled {Count} statistics.", statistics.Count);
  }

  private static AttributeModel? Find(string idOrSlug, IReadOnlyDictionary<Guid, AttributeModel> attributesById, IReadOnlyDictionary<string, AttributeModel> attributesBySlug)
  {
    if ((Guid.TryParse(idOrSlug, out Guid id) && attributesById.TryGetValue(id, out AttributeModel? attribute))
      || attributesBySlug.TryGetValue(Normalize(idOrSlug), out attribute))
    {
      return attribute;
    }

    return null;
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<StatisticPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\statistics.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<StatisticPayload> records = csv.GetRecordsAsync<StatisticPayload>(cancellationToken);

    List<StatisticPayload> statistics = [];
    await foreach (StatisticPayload statistic in records)
    {
      statistics.Add(statistic);
    }

    return statistics.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Statistic> statistics, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(statistics, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\statistics.json", json, Constants.Encoding, cancellationToken);
  }
}
