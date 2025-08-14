using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileSkills : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles skill rules.";
}

internal class CompileSkillsHandler : ICommandHandler<CompileSkills>
{
  private readonly ILogger<CompileSkillsHandler> _logger;

  public CompileSkillsHandler(ILogger<CompileSkillsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileSkills command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("data\\output\\attributes.json", Constants.Encoding, cancellationToken);
    IReadOnlyCollection<AttributeModel> attributes = JsonSerializer.Deserialize<IReadOnlyCollection<AttributeModel>>(json, Constants.SerializerOptions) ?? [];
    Dictionary<Guid, AttributeModel> attributesById = attributes.ToDictionary(x => x.Id, x => x);
    Dictionary<string, AttributeModel> attributesBySlug = attributes.ToDictionary(x => Normalize(x.Slug), x => x);

    IReadOnlyCollection<SkillPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, SkillPayload[]> skillsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, SkillPayload[]> skillsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Skill> skills = [];
    SkillValidator validator = new();
    foreach (SkillPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Skill 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (skillsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Skill ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (skillsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Skill Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Skill skill = new()
      {
        Id = payload.Id,
        Slug = slug,
        Value = payload.Value,
        Name = payload.Name.Trim(),
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim(),
        Notes = payload.Notes?.CleanTrim()
      };

      if (!string.IsNullOrWhiteSpace(payload.Attribute))
      {
        AttributeModel? attribute = Find(payload.Attribute, attributesById, attributesBySlug);
        if (attribute is null)
        {
          _logger.LogWarning("Attribute for skill 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", skill.Id, skill.Name, payload.Attribute);
          continue;
        }
        else
        {
          skill.AttributeId = attribute.Id;
        }
      }

      skills.Add(skill);
    }

    await LoadAsync(skills, cancellationToken);

    _logger.LogInformation("Compiled {Count} skills.", skills.Count);
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

  private static async Task<IReadOnlyCollection<SkillPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\skills.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<SkillPayload> records = csv.GetRecordsAsync<SkillPayload>(cancellationToken);

    List<SkillPayload> skills = [];
    await foreach (SkillPayload skill in records)
    {
      skills.Add(skill);
    }

    return skills.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Skill> skills, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(skills, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\skills.json", json, Constants.Encoding, cancellationToken);
  }
}
