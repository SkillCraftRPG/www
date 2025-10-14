using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractCastesTask : ExtractionTask
{
  public override string? Description => "Extracts the Caste rules.";
}

internal class ExtractCastesTaskHandler : ICommandHandler<ExtractCastesTask, TaskResult>
{
  private const string Path = @"output\castes.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<CasteEntity> _castes;
  private readonly ILogger<ExtractCastesTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractCastesTaskHandler(RulesContext context, ILogger<ExtractCastesTaskHandler> logger, IExtractionSerializer serializer)
  {
    _castes = context.Castes;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractCastesTask command, CancellationToken cancellationToken)
  {
    CasteEntity[] entities = await _castes.AsNoTracking()
      .Include(x => x.Skill)
      .Include(x => x.Feature)
      .OrderBy(x => x.SlugNormalized)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Castes} caste(s) from database.", entities.Length);

    List<CasteDto> castes = new(capacity: entities.Length);
    foreach (CasteEntity entity in entities)
    {
      castes.Add(ExtractionMapper.ToCaste(entity));
    }

    string json = _serializer.Serialize(castes);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Castes} caste(s) into '{Path}'.", castes.Count, Path);

    return new TaskResult();
  }
}
