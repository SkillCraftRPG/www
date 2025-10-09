using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractAttributesTask : ExtractionTask
{
  public override string? Description => "Extracts the Attribute rules.";
}

internal class ExtractAttributesTaskHandler : ICommandHandler<ExtractAttributesTask, TaskResult>
{
  private const string Path = @"output\attributes.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<AttributeEntity> _attributes;
  private readonly ILogger<ExtractAttributesTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractAttributesTaskHandler(RulesContext context, ILogger<ExtractAttributesTaskHandler> logger, IExtractionSerializer serializer)
  {
    _attributes = context.Attributes;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractAttributesTask command, CancellationToken cancellationToken)
  {
    AttributeEntity[] entities = await _attributes.AsNoTracking().ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Attributes} attribute(s) from database.", entities.Length);

    List<AttributeDto> attributes = new(capacity: entities.Length);
    foreach (AttributeEntity entity in entities)
    {
      attributes.Add(ExtractionMapper.ToAttribute(entity));
    }

    string json = _serializer.Serialize(attributes);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Attributes} attribute(s) into '{Path}'.", attributes.Count, Path);

    return new TaskResult();
  }
}
