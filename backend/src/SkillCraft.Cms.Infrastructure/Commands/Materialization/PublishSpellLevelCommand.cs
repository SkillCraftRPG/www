using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishSpellLevelCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishSpellLevelCommandHandler : ICommandHandler<PublishSpellLevelCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishSpellLevelCommandHandler> _logger;

  public PublishSpellLevelCommandHandler(RulesContext context, ILogger<PublishSpellLevelCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishSpellLevelCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    SpellLevelEntity? spellLevel = await _context.SpellLevels.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (spellLevel is null)
    {
      spellLevel = new SpellLevelEntity(command.Event);
      _context.SpellLevels.Add(spellLevel);
    }

    await SetSpellAsync(spellLevel, invariant, cancellationToken);

    spellLevel.Level = (int)invariant.GetNumber(SpellLevels.Level);
    spellLevel.Name = locale.DisplayName?.Value;

    SetCastingTime(spellLevel, invariant);
    spellLevel.IsRitual = invariant.GetBoolean(SpellLevels.IsRitual);

    spellLevel.Duration = (int?)invariant.TryGetNumber(SpellLevels.Duration);
    SetDurationUnit(spellLevel, invariant);
    spellLevel.IsConcentration = invariant.GetBoolean(SpellLevels.IsConcentration);

    spellLevel.Range = (int)invariant.GetNumber(SpellLevels.Range);

    spellLevel.IsSomatic = invariant.GetBoolean(SpellLevels.IsSomatic);
    spellLevel.IsVerbal = invariant.GetBoolean(SpellLevels.IsVerbal);
    spellLevel.Focus = locale.TryGetString(SpellLevels.Focus);
    spellLevel.Material = locale.TryGetString(SpellLevels.Material);

    spellLevel.Description = locale.TryGetString(SpellLevels.HtmlContent);

    spellLevel.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The spell level '{SpellLevel}' has been published.", spellLevel);

    return new CommandResult();
  }

  private void SetCastingTime(SpellLevelEntity spellLevel, ContentLocale invariant)
  {
    string castingTime = "?";

    IReadOnlyCollection<string> castingTimes = invariant.GetSelect(SpellLevels.CastingTime);
    if (castingTimes.Count < 1)
    {
      _logger.LogWarning("No casting time was provided, when exactly one is expected, for spell level '{SpellLevel}'.", spellLevel);
    }
    else if (castingTimes.Count > 1)
    {
      _logger.LogWarning("Many casting times ({Count}) were provided, when exactly one is expected, for spell level '{SpellLevel}'.", castingTimes.Count, spellLevel);
    }
    else
    {
      castingTime = castingTimes.Single();
    }

    spellLevel.CastingTime = castingTime;
  }

  private void SetDurationUnit(SpellLevelEntity spellLevel, ContentLocale invariant)
  {
    IReadOnlyCollection<string> durationUnits = invariant.GetSelect(SpellLevels.DurationUnit);
    if (durationUnits.Count > 1)
    {
      _logger.LogWarning("Many duration units ({Count}) were provided, when at most one is expected, for spell level '{SpellLevel}'.", durationUnits.Count, spellLevel);
    }
    else if (durationUnits.Count == 1)
    {
      string durationUnitValue = durationUnits.Single();
      if (Enum.TryParse(durationUnitValue, ignoreCase: true, out DurationUnit durationUnit) && Enum.IsDefined(durationUnit))
      {
        spellLevel.DurationUnit = durationUnit;
        return;
      }
      _logger.LogWarning("The duration unit '{DurationUnit}' is not valid, for spell level '{SpellLevel}'.", durationUnitValue, spellLevel);
    }

    spellLevel.DurationUnit = null;
  }

  private async Task SetSpellAsync(SpellLevelEntity spellLevel, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> spellIds = invariant.GetRelatedContents(SpellLevels.Spell);
    if (spellIds.Count < 1)
    {
      _logger.LogWarning("No spell was provided, when exactly one is expected, for spell level '{SpellLevel}'.", spellLevel);
    }
    else if (spellIds.Count > 1)
    {
      _logger.LogWarning("Many spells ({Count}) were provided, when exactly one is expected, for spell level '{SpellLevel}'.", spellIds.Count, spellLevel);
    }
    else
    {
      Guid spellId = spellIds.Single();
      SpellEntity? spell = await _context.Spells.SingleOrDefaultAsync(x => x.Id == spellId, cancellationToken);
      if (spell is null)
      {
        _logger.LogWarning("The spell 'Id={SpellId}' was not found for spell level '{SpellLevel}'.", spellId, spellLevel);
      }
      else
      {
        spellLevel.SetSpell(spell);
      }
    }
  }
}
