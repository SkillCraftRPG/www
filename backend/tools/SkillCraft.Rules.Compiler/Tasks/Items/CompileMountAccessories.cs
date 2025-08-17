using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileMountAccessories : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles mount accessory rules.";
}

internal class CompileMountAccessoriesHandler : ICommandHandler<CompileMountAccessories>
{
  private readonly ILogger<CompileMountAccessoriesHandler> _logger;

  public CompileMountAccessoriesHandler(ILogger<CompileMountAccessoriesHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileMountAccessories command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<MountAccessoryPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, MountAccessoryPayload[]> mountAccessoriesById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, MountAccessoryPayload[]> mountAccessoriesBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<MountAccessory> mountAccessories = [];
    MountAccessoryValidator validator = new();
    foreach (MountAccessoryPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Mount accessory 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (mountAccessoriesById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Mount accessory ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (mountAccessoriesBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Mount accessory Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      MountAccessory mountAccessory = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        IsPriceMultiplier = payload.IsPriceMultiplier,
        Weight = payload.Weight,
        IsWeightMultiplier = payload.IsWeightMultiplier,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      mountAccessories.Add(mountAccessory);
    }

    await LoadAsync(mountAccessories, cancellationToken);

    _logger.LogInformation("Compiled {Count} mount accessories.", mountAccessories.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<MountAccessoryPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\mount_accessories.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<MountAccessoryPayload> records = csv.GetRecordsAsync<MountAccessoryPayload>(cancellationToken);

    List<MountAccessoryPayload> mountAccessories = [];
    await foreach (MountAccessoryPayload mountAccessory in records)
    {
      mountAccessories.Add(mountAccessory);
    }

    return mountAccessories.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<MountAccessory> mountAccessories, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(mountAccessories, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\mount_accessories.json", json, Constants.Encoding, cancellationToken);
  }
}
