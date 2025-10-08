using Krakenar.Contracts.Fields;
using Krakenar.Core;
using SkillCraft.Cms.Seeding.Krakenar.Models;

namespace SkillCraft.Cms.Seeding.Krakenar.Tasks;

internal class SeedFieldTypesTask : SeedingTask
{
  public override string? Description => "Seeds the Field Types into Krakenar.";
}

internal class SeedFieldTypesTaskHandler : ICommandHandler<SeedFieldTypesTask, TaskResult>
{
  private readonly IFieldTypeService _fieldTypeService;
  private readonly ILogger<SeedFieldTypesTaskHandler> _logger;

  public SeedFieldTypesTaskHandler(IFieldTypeService fieldTypeService, ILogger<SeedFieldTypesTaskHandler> logger)
  {
    _fieldTypeService = fieldTypeService;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedFieldTypesTask _, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Krakenar/data/field_types.json", Encoding.UTF8, cancellationToken);
    IEnumerable<FieldTypePayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<FieldTypePayload>>(json);
    if (payloads is not null)
    {
      foreach (FieldTypePayload payload in payloads)
      {
        CreateOrReplaceFieldTypeResult result = await _fieldTypeService.CreateOrReplaceAsync(payload, payload.Id, version: null, cancellationToken);
        FieldType fieldType = result.FieldType ?? throw new InvalidOperationException($"'FieldTypeService.CreateOrReplaceAsync' returned null for field type 'Id={payload.Id}'.");
        _logger.LogInformation("The field type '{FieldType}' was {Action}.", fieldType.DisplayName ?? fieldType.UniqueName, result.Created ? "created" : "replaced");
      }
    }

    return new TaskResult();
  }
}
