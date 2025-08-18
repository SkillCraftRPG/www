using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileMounts : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles mount rules.";
}

internal class CompileMountsHandler : ICommandHandler<CompileMounts>
{
  private readonly ILogger<CompileMountsHandler> _logger;

  public CompileMountsHandler(ILogger<CompileMountsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileMounts command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<MountPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, MountPayload[]> mountsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, MountPayload[]> mountsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Mount> mounts = [];
    MountValidator validator = new();
    foreach (MountPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Mount 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (mountsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Mount ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (mountsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Mount Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Mount mount = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Vigor = payload.Vigor,
        Size = payload.Size,
        Load = payload.Load,
        Speed = payload.Speed,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      mounts.Add(mount);
    }

    await LoadAsync(mounts, cancellationToken);

    _logger.LogInformation("Compiled {Count} mounts.", mounts.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<MountPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\mounts.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<MountPayload> records = csv.GetRecordsAsync<MountPayload>(cancellationToken);

    List<MountPayload> mounts = [];
    await foreach (MountPayload mount in records)
    {
      mounts.Add(mount);
    }

    return mounts.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Mount> mounts, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(mounts, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\mounts.json", json, Constants.Encoding, cancellationToken);
  }
}
