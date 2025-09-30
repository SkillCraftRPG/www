using FluentValidation.Results;
using Krakenar.Core;
using SkillCraft.Cms.Seeding.Game.Models;
using SkillCraft.Cms.Seeding.Game.Validators;
using SkillCraft.Cms.Seeding.Krakenar.Tasks;

namespace SkillCraft.Cms.Seeding.Game.Tasks;

internal class SeedSpecializationsTask : SeedingTask
{
  public override string? Description => "Seeds the Specializations into the database.";
}

internal class SeedSpecializationsTaskHandler : ICommandHandler<SeedSpecializationsTask, SeedingTaskResult>
{
  private readonly ILogger<SeedContentTypesTaskHandler> _logger;

  public SeedSpecializationsTaskHandler(ILogger<SeedContentTypesTaskHandler> logger)
  {
    _logger = logger;
  }

  public async Task<SeedingTaskResult> HandleAsync(SeedSpecializationsTask command, CancellationToken cancellationToken)
  {
    SpecializationValidator validator = new();

    string[] paths = Directory.GetFiles("Game/data/specializations", "*.json");
    foreach (string path in paths)
    {
      string slug = Path.GetFileNameWithoutExtension(path);

      string json = await File.ReadAllTextAsync(path, Encoding.UTF8, cancellationToken);
      SpecializationPayload? specialization = SeedingSerializer.Deserialize<SpecializationPayload>(json);
      if (specialization is null)
      {
        _logger.LogWarning("No specialization was deserialized for specialization '{Slug}'.", slug);
        continue;
      }

      ValidationResult result = validator.Validate(specialization);
      if (!result.IsValid)
      {
        string errors = SeedingSerializer.Serialize(result.Errors);
        _logger.LogWarning("Validation failed for specialization '{Slug}': {Errors}.", slug, errors);
        continue;
      }

      // TODO(fpion): implement
    }

    return new SeedingTaskResult();
  }
}
