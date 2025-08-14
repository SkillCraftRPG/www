using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileCustomizations : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles customization rules.";
}

internal class CompileCustomizationsHandler : ICommandHandler<CompileCustomizations>
{
  private readonly ILogger<CompileCustomizationsHandler> _logger;

  public CompileCustomizationsHandler(ILogger<CompileCustomizationsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileCustomizations command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<CustomizationPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, CustomizationPayload[]> customizationsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, CustomizationPayload[]> customizationsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Customization> customizations = [];
    CustomizationValidator validator = new();
    foreach (CustomizationPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Customization 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (customizationsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Customization ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (customizationsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Customization Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Customization customization = new()
      {
        Id = payload.Id,
        Kind = payload.Kind,
        Slug = slug,
        Name = payload.Name.Trim(),
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim().Replace("\\n", "\n"),
        Notes = payload.Notes?.CleanTrim()?.Replace("\\n", "\n")
      };

      customizations.Add(customization);
    }

    await LoadAsync(customizations, cancellationToken);

    _logger.LogInformation("Compiled {Count} customizations.", customizations.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<CustomizationPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\customizations.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<CustomizationPayload> records = csv.GetRecordsAsync<CustomizationPayload>(cancellationToken);

    List<CustomizationPayload> customizations = [];
    await foreach (CustomizationPayload customization in records)
    {
      customizations.Add(customization);
    }

    return customizations.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Customization> customizations, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(customizations, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\customizations.json", json, Constants.Encoding, cancellationToken);
  }
}
