using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileAttributes : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles attribute rules.";
}

internal class CompileAttributesHandler : ICommandHandler<CompileAttributes>
{
  private readonly ILogger<CompileAttributesHandler> _logger;

  public CompileAttributesHandler(ILogger<CompileAttributesHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileAttributes command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<AttributePayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, AttributePayload[]> attributesById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, AttributePayload[]> attributesBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<AttributeModel> attributes = [];
    AttributeValidator validator = new();
    foreach (AttributePayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Attribute 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (attributesById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Attribute ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (attributesBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Attribute Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      AttributeModel attribute = new()
      {
        Id = payload.Id,
        Slug = slug,
        Value = payload.Value,
        Category = payload.Category,
        Name = payload.Name.Trim(),
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim(),
        Notes = payload.Notes?.CleanTrim()
      };

      attributes.Add(attribute);
    }

    await LoadAsync(attributes, cancellationToken);

    _logger.LogInformation("Compiled {Count} attributes.", attributes.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<AttributePayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\attributes.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<AttributePayload> records = csv.GetRecordsAsync<AttributePayload>(cancellationToken);

    List<AttributePayload> attributes = [];
    await foreach (AttributePayload attribute in records)
    {
      attributes.Add(attribute);
    }

    return attributes.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<AttributeModel> attributes, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(attributes, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\attributes.json", json, Constants.Encoding, cancellationToken);
  }
}
