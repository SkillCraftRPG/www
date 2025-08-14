using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileCastes : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles caste rules.";
}

internal class CompileCastesHandler : ICommandHandler<CompileCastes>
{
  private readonly ILogger<CompileCastesHandler> _logger;

  public CompileCastesHandler(ILogger<CompileCastesHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileCastes command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("data\\output\\skills.json", Constants.Encoding, cancellationToken);
    IReadOnlyCollection<Skill> skills = JsonSerializer.Deserialize<IReadOnlyCollection<Skill>>(json, Constants.SerializerOptions) ?? [];
    Dictionary<Guid, Skill> skillsById = skills.ToDictionary(x => x.Id, x => x);
    Dictionary<string, Skill> skillsBySlug = skills.ToDictionary(x => Normalize(x.Slug), x => x);

    IReadOnlyCollection<CastePayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, CastePayload[]> castesById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, CastePayload[]> castesBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Caste> castes = [];
    CasteValidator validator = new();
    foreach (CastePayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Caste 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (castesById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Caste ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (castesBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Caste Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Caste caste = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        WealthRoll = payload.WealthRoll,
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim().Replace("\\n", "\n"),
        Feature = new Feature
        {
          Name = payload.FeatureName.Trim(),
          Description = payload.FeatureDescription.Trim().Replace("\\n", "\n")
        },
        Notes = payload.Notes?.CleanTrim()?.Replace("\\n", "\n")
      };

      Skill? skill = Find(payload.Skill, skillsById, skillsBySlug);
      if (skill is null)
      {
        _logger.LogWarning("Skill for caste 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", caste.Id, caste.Name, payload.Skill);
        continue;
      }
      else
      {
        caste.SkillId = skill.Id;
      }

      castes.Add(caste);
    }

    await LoadAsync(castes, cancellationToken);

    _logger.LogInformation("Compiled {Count} castes.", castes.Count);
  }

  private static Skill? Find(string idOrSlug, IReadOnlyDictionary<Guid, Skill> skillsById, IReadOnlyDictionary<string, Skill> skillsBySlug)
  {
    if ((Guid.TryParse(idOrSlug, out Guid id) && skillsById.TryGetValue(id, out Skill? skill))
      || skillsBySlug.TryGetValue(Normalize(idOrSlug), out skill))
    {
      return skill;
    }

    return null;
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<CastePayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\castes.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<CastePayload> records = csv.GetRecordsAsync<CastePayload>(cancellationToken);

    List<CastePayload> castes = [];
    await foreach (CastePayload caste in records)
    {
      castes.Add(caste);
    }

    return castes.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Caste> castes, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(castes, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\castes.json", json, Constants.Encoding, cancellationToken);
  }
}
