using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileFirearms : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles firearm rules.";
}

internal class CompileFirearmsHandler : ICommandHandler<CompileFirearms>
{
  private readonly ILogger<CompileFirearmsHandler> _logger;

  public CompileFirearmsHandler(ILogger<CompileFirearmsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileFirearms command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<FirearmPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, FirearmPayload[]> firearmsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, FirearmPayload[]> firearmsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Weapon> firearms = [];
    FirearmValidator validator = new();
    foreach (FirearmPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Firearm 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (firearmsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Firearm ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (firearmsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Firearm Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Weapon firearm = new()
      {
        Id = payload.Id,
        Category = payload.Category,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Reload = payload.Reload,
        Special = payload.Special?.CleanTrim()?.Replace("\\n", "\n"),
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      if (!string.IsNullOrWhiteSpace(payload.DamageRoll) && payload.DamageType.HasValue)
      {
        firearm.Damage = new WeaponDamage(payload.DamageRoll, payload.DamageType.Value);
      }

      if (payload.AmmunitionStandard.HasValue)
      {
        firearm.Ammunition = new WeaponRange(payload.AmmunitionStandard.Value, payload.AmmunitionLong ?? 0);
      }

      HashSet<WeaponProperty> properties = [WeaponProperty.Loading];
      if (!string.IsNullOrWhiteSpace(payload.Properties))
      {
        properties.AddRange(payload.Properties.Split(',').Select(value => Enum.Parse<WeaponProperty>(value.Trim(), ignoreCase: true)));
      }
      firearm.Properties = properties.OrderBy(x => x).ToList();

      firearms.Add(firearm);
    }

    await LoadAsync(firearms, cancellationToken);

    _logger.LogInformation("Compiled {Count} firearms.", firearms.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<FirearmPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\firearms.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<FirearmPayload> records = csv.GetRecordsAsync<FirearmPayload>(cancellationToken);

    List<FirearmPayload> firearms = [];
    await foreach (FirearmPayload firearm in records)
    {
      firearms.Add(firearm);
    }

    return firearms.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Weapon> firearms, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(firearms, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\firearms.json", json, Constants.Encoding, cancellationToken);
  }
}
