using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Infrastructure;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Rules.Extractor.Tasks;

internal class ExtractSpellsTask : ExtractionTask
{
  public override string? Description => "Extracts the Spell rules.";
}

internal class ExtractSpellsTaskHandler : ICommandHandler<ExtractSpellsTask, TaskResult>
{
  private const string Path = @"output\spells.json";
  private static readonly Encoding _encoding = Encoding.UTF8;

  private readonly DbSet<SpellEntity> _spells;
  private readonly ILogger<ExtractSpellsTaskHandler> _logger;
  private readonly IExtractionSerializer _serializer;

  public ExtractSpellsTaskHandler(RulesContext context, ILogger<ExtractSpellsTaskHandler> logger, IExtractionSerializer serializer)
  {
    _spells = context.Spells;
    _logger = logger;
    _serializer = serializer;
  }

  public async Task<TaskResult> HandleAsync(ExtractSpellsTask command, CancellationToken cancellationToken)
  {
    SpellEntity[] entities = await _spells.AsNoTracking()
      .Include(x => x.Levels)
      .ToArrayAsync(cancellationToken);
    _logger.LogInformation("Retrieved {Spells} spell(s) from database.", entities.Length);

    List<SpellDto> spells = new(capacity: entities.Length);
    foreach (SpellEntity entity in entities)
    {
      spells.Add(ExtractionMapper.ToSpell(entity));
    }

    string json = _serializer.Serialize(spells);
    await File.WriteAllTextAsync(Path, json, _encoding, cancellationToken);
    _logger.LogInformation("Serialized {Spells} spell(s) into '{Path}'.", spells.Count, Path);

    return new TaskResult();
  }
}
