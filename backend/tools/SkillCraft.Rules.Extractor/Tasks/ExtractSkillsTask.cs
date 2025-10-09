using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractSkillsTask : ExtractionTask
{
  public override string? Description => "Extracts the Skill rules.";
}

internal class ExtractSkillsTaskHandler : ICommandHandler<ExtractSkillsTask, TaskResult>
{
  private const string Path = @"output\skills.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<SkillEntity> _skills;
  private readonly ILogger<ExtractSkillsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractSkillsTaskHandler(RulesContext context, ILogger<ExtractSkillsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _skills = context.Skills;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractSkillsTask command, CancellationToken cancellationToken)
  {
    SkillEntity[] entities = await _skills.AsNoTracking()
      .Include(x => x.Attribute)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Skills} skill(s) from database.", entities.Length);

    List<SkillDto> skills = new(capacity: entities.Length);
    foreach (SkillEntity entity in entities)
    {
      skills.Add(ExtractionMapper.ToSkill(entity));
    }

    string json = _serializer.Serialize(skills);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Skills} skill(s) into '{Path}'.", skills.Count, Path);

    return new TaskResult();
  }
}
