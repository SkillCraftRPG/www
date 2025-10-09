using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractSpecializationsTask : ExtractionTask
{
  public override string? Description => "Extracts the Specialization rules.";
}

internal class ExtractSpecializationsTaskHandler : ICommandHandler<ExtractSpecializationsTask, TaskResult>
{
  private const string Path = @"output\specializations.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<SpecializationEntity> _specializations;
  private readonly ILogger<ExtractSpecializationsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractSpecializationsTaskHandler(RulesContext context, ILogger<ExtractSpecializationsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _specializations = context.Specializations;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractSpecializationsTask command, CancellationToken cancellationToken)
  {
    SpecializationEntity[] entities = await _specializations.AsNoTracking()
      .Include(x => x.MandatoryTalent)
      .Include(x => x.DiscountedTalents).ThenInclude(x => x.Talent)
      .Include(x => x.Features).ThenInclude(x => x.Feature)
      .Include(x => x.OptionalTalents).ThenInclude(x => x.Talent)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Specializations} specialization(s) from database.", entities.Length);

    List<SpecializationDto> specializations = new(capacity: entities.Length);
    foreach (SpecializationEntity entity in entities)
    {
      specializations.Add(ExtractionMapper.ToSpecialization(entity));
    }

    string json = _serializer.Serialize(specializations);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Specializations} specialization(s) into '{Path}'.", specializations.Count, Path);

    return new TaskResult();
  }
}
