using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Core;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishTalentCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishTalentCommandHandler : ICommandHandler<PublishTalentCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishTalentCommandHandler> _logger;

  public PublishTalentCommandHandler(RulesContext context, ILogger<PublishTalentCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishTalentCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    TalentEntity? talent = await _context.Talents.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (talent is null)
    {
      talent = new TalentEntity(command.Event);
      _context.Talents.Add(talent);
    }

    talent.Slug = locale.UniqueName.Value;
    talent.Name = locale.DisplayName?.Value ?? ToName(locale.UniqueName.Value);

    talent.Tier = (int)invariant.GetNumber(Talents.Tier);
    talent.AllowMultiplePurchases = invariant.GetBoolean(Talents.AllowMultiplePurchases);

    GameSkill? skill = null;
    IReadOnlyCollection<string>? skills = invariant.TryGetSelect(Talents.Skill);
    if (skills is not null)
    {
      if (skills.Count > 1)
      {
        _logger.LogWarning("Many skills ({Count}) were provided, when at most one is expected, for talent '{Talent}'.", skills.Count, talent);
      }
      else if (skills.Count == 1)
      {
        string skillValue = skills.Single();
        if (Enum.TryParse(skillValue, out GameSkill parsedSkill))
        {
          skill = parsedSkill;
        }
        else
        {
          _logger.LogWarning("The skill '{Skill}' was not parsed, for talent '{Talent}'.", skillValue, talent);
        }
      }
    }
    talent.Skill = skill;

    TalentEntity? requiredTalent = null;
    IReadOnlyCollection<Guid>? requiredTalentIds = invariant.TryGetRelatedContents(Talents.RequiredTalent);
    if (requiredTalentIds is not null)
    {
      if (requiredTalentIds.Count > 1)
      {
        _logger.LogWarning("Many required talents ({Count}) were provided, when at most one is expected, for talent '{Talent}'.", requiredTalentIds.Count, talent);
      }
      else if (requiredTalentIds.Count == 1)
      {
        Guid requiredTalentId = requiredTalentIds.Single();
        requiredTalent = await _context.Talents.SingleOrDefaultAsync(x => x.Id == requiredTalentId, cancellationToken);
        if (requiredTalent is null)
        {
          _logger.LogWarning("The required talent 'Id={RequiredTalentId}' was not found, for talent '{Talent}'.", requiredTalentId, talent);
        }
      }
    }
    talent.SetRequiredTalent(requiredTalent);

    talent.Summary = locale.TryGetString(Talents.Summary);
    talent.Description = locale.TryGetString(Talents.HtmlContent);

    talent.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The talent '{Talent}' has been published.", talent);

    return new CommandResult();
  }

  private static string ToName(string slug) => string.Join(' ', slug.Split('-').Select(Capitalize));
  private static string Capitalize(string value) => string.Concat(char.ToUpperInvariant(value.First()), value[1..]);
}
