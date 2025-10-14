using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractEducationsTask : ExtractionTask
{
  public override string? Description => "Extracts the Education rules.";
}

internal class ExtractEducationsTaskHandler : ICommandHandler<ExtractEducationsTask, TaskResult>
{
  private const string Path = @"output\educations.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<EducationEntity> _educations;
  private readonly ILogger<ExtractEducationsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractEducationsTaskHandler(RulesContext context, ILogger<ExtractEducationsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _educations = context.Educations;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractEducationsTask command, CancellationToken cancellationToken)
  {
    EducationEntity[] entities = await _educations.AsNoTracking()
      .Include(x => x.Skill)
      .Include(x => x.Feature)
      .OrderBy(x => x.SlugNormalized)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Educations} education(s) from database.", entities.Length);

    List<EducationDto> educations = new(capacity: entities.Length);
    foreach (EducationEntity entity in entities)
    {
      educations.Add(ExtractionMapper.ToEducation(entity));
    }

    string json = _serializer.Serialize(educations);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Educations} education(s) into '{Path}'.", educations.Count, Path);

    return new TaskResult();
  }
}
