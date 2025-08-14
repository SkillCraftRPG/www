using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileEducations : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles education rules.";
}

internal class CompileEducationsHandler : ICommandHandler<CompileEducations>
{
  private readonly ILogger<CompileEducationsHandler> _logger;

  public CompileEducationsHandler(ILogger<CompileEducationsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileEducations command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("data\\output\\skills.json", Constants.Encoding, cancellationToken);
    IReadOnlyCollection<Skill> skills = JsonSerializer.Deserialize<IReadOnlyCollection<Skill>>(json, Constants.SerializerOptions) ?? [];
    Dictionary<Guid, Skill> skillsById = skills.ToDictionary(x => x.Id, x => x);
    Dictionary<string, Skill> skillsBySlug = skills.ToDictionary(x => Normalize(x.Slug), x => x);

    IReadOnlyCollection<EducationPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, EducationPayload[]> educationsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, EducationPayload[]> educationsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Education> educations = [];
    EducationValidator validator = new();
    foreach (EducationPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Education 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (educationsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Education ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (educationsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Education Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Education education = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        WealthMultiplier = payload.WealthMultiplier,
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim(),
        Feature = new Feature
        {
          Name = payload.FeatureName.Trim(),
          Description = payload.FeatureDescription.Trim()
        },
        Notes = payload.Notes?.CleanTrim()
      };

      Skill? skill = Find(payload.Skill, skillsById, skillsBySlug);
      if (skill is null)
      {
        _logger.LogWarning("Skill for education 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", education.Id, education.Name, payload.Skill);
        continue;
      }
      else
      {
        education.SkillId = skill.Id;
      }

      educations.Add(education);
    }

    await LoadAsync(educations, cancellationToken);

    _logger.LogInformation("Compiled {Count} educations.", educations.Count);
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

  private static async Task<IReadOnlyCollection<EducationPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\educations.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<EducationPayload> records = csv.GetRecordsAsync<EducationPayload>(cancellationToken);

    List<EducationPayload> educations = [];
    await foreach (EducationPayload education in records)
    {
      educations.Add(education);
    }

    return educations.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Education> educations, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(educations, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\educations.json", json, Constants.Encoding, cancellationToken);
  }
}
