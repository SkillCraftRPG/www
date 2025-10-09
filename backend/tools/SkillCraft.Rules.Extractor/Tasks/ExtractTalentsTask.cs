using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractTalentsTask : ExtractionTask
{
  public override string? Description => "Extracts the Talent rules.";
}

internal class ExtractTalentsTaskHandler : ICommandHandler<ExtractTalentsTask, TaskResult>
{
  private const string Path = @"output\talents.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<TalentEntity> _talents;
  private readonly ILogger<ExtractTalentsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractTalentsTaskHandler(RulesContext context, ILogger<ExtractTalentsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _talents = context.Talents;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractTalentsTask command, CancellationToken cancellationToken)
  {
    TalentEntity[] entities = await _talents.AsNoTracking()
      .Include(x => x.Skill)
      .Include(x => x.RequiredTalent)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Talents} talent(s) from database.", entities.Length);

    List<TalentDto> talents = new(capacity: entities.Length);
    foreach (TalentEntity entity in entities)
    {
      talents.Add(ExtractionMapper.ToTalent(entity));
    }

    string json = _serializer.Serialize(talents);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Talents} talent(s) into '{Path}'.", talents.Count, Path);

    return new TaskResult();
  }
}
