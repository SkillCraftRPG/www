using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractCustomizationsTask : ExtractionTask
{
  public override string? Description => "Extracts the Customization rules.";
}

internal class ExtractCustomizationsTaskHandler : ICommandHandler<ExtractCustomizationsTask, TaskResult>
{
  private const string Path = @"output\customizations.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<CustomizationEntity> _customizations;
  private readonly ILogger<ExtractCustomizationsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractCustomizationsTaskHandler(RulesContext context, ILogger<ExtractCustomizationsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _customizations = context.Customizations;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractCustomizationsTask command, CancellationToken cancellationToken)
  {
    CustomizationEntity[] entities = await _customizations.AsNoTracking()
      .OrderBy(x => x.SlugNormalized)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Customizations} customization(s) from database.", entities.Length);

    List<CustomizationDto> customizations = new(capacity: entities.Length);
    foreach (CustomizationEntity entity in entities)
    {
      customizations.Add(ExtractionMapper.ToCustomization(entity));
    }

    string json = _serializer.Serialize(customizations);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Customizations} customization(s) into '{Path}'.", customizations.Count, Path);

    return new TaskResult();
  }
}
