using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models;
using SkillCraft.Rules.Compiler.Validators;

namespace SkillCraft.Rules.Compiler.Tasks;

internal class CompileTalents : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles talent rules.";
}

internal class CompileTalentsHandler : ICommandHandler<CompileTalents>
{
  private readonly ILogger<CompileTalentsHandler> _logger;

  public CompileTalentsHandler(ILogger<CompileTalentsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileTalents command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("data\\output\\skills.json", Constants.Encoding, cancellationToken);
    IReadOnlyCollection<Skill> skills = JsonSerializer.Deserialize<IReadOnlyCollection<Skill>>(json, Constants.SerializerOptions) ?? [];
    Dictionary<Guid, Skill> skillsById = skills.ToDictionary(x => x.Id, x => x);
    Dictionary<string, Skill> skillsBySlug = skills.ToDictionary(x => Normalize(x.Slug), x => x);

    IReadOnlyCollection<TalentPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, TalentPayload[]> talentsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, TalentPayload[]> talentsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Talent> talents = [];
    TalentValidator validator = new();
    foreach (TalentPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Talent 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (talentsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Talent ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (talentsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Talent Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Talent talent = new()
      {
        Id = payload.Id,
        Tier = payload.Tier,
        Slug = slug,
        Name = payload.Name.Trim(),
        AllowMultiplePurchases = payload.AllowMultiplePurchases,
        Summary = payload.Summary.Trim(),
        Description = payload.Description.Trim(),
        Notes = payload.Notes?.CleanTrim()
      };

      if (!string.IsNullOrWhiteSpace(payload.Skill))
      {
        Skill? skill = Find(payload.Skill, skillsById, skillsBySlug);
        if (skill is null)
        {
          _logger.LogWarning("Skill for talent 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", talent.Id, talent.Name, payload.Skill);
          continue;
        }
        else
        {
          talent.SkillId = skill.Id;
        }
      }

      if (!string.IsNullOrWhiteSpace(payload.RequiredTalent))
      {
        TalentPayload? requiredTalent = Find(payload.RequiredTalent, talentsById, talentsBySlug);
        if (requiredTalent is null)
        {
          _logger.LogWarning("Required talent for talent 'Id={Id}, Name={Name}' was not found: {IdOrSlug}", talent.Id, talent.Name, payload.RequiredTalent);
          continue;
        }
        else
        {
          talent.RequiredTalentId = requiredTalent.Id;
        }
      }

      talents.Add(talent);
    }

    await LoadAsync(talents, cancellationToken);

    _logger.LogInformation("Compiled {Count} talents.", talents.Count);
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
  private static TalentPayload? Find(string idOrSlug, IReadOnlyDictionary<Guid, TalentPayload[]> talentsById, IReadOnlyDictionary<string, TalentPayload[]> talentsBySlug)
  {
    if ((Guid.TryParse(idOrSlug, out Guid id) && talentsById.TryGetValue(id, out TalentPayload[]? talents) && talents.Length == 1)
      || (talentsBySlug.TryGetValue(Normalize(idOrSlug), out talents) && talents.Length == 1))
    {
      return talents.Single();
    }

    return null;
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<TalentPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\talents.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<TalentPayload> records = csv.GetRecordsAsync<TalentPayload>(cancellationToken);

    List<TalentPayload> talents = [];
    await foreach (TalentPayload talent in records)
    {
      talents.Add(talent);
    }

    return talents.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Talent> talents, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(talents, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\talents.json", json, Constants.Encoding, cancellationToken);
  }
}
