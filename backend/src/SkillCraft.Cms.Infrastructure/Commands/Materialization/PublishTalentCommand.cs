using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    talent.Slug = locale.GetString(Talents.Slug);
    talent.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    talent.Tier = (int)invariant.GetNumber(Talents.Tier);
    talent.AllowMultiplePurchases = invariant.GetBoolean(Talents.AllowMultiplePurchases);

    SkillEntity? skill = null;
    IReadOnlyCollection<Guid>? skillIds = invariant.TryGetRelatedContents(Talents.Skill);
    if (skillIds is not null)
    {
      if (skillIds.Count > 1)
      {
        _logger.LogWarning("Many skills ({Count}) were provided, when at most one is expected, for talent '{Talent}'.", skillIds.Count, talent);
      }
      else if (skillIds.Count == 1)
      {
        Guid skillId = skillIds.Single();
        skill = await _context.Skills.SingleOrDefaultAsync(x => x.Id == skillId, cancellationToken);
        if (skill is null)
        {
          _logger.LogWarning("The skill 'Id={SkillId}' was not found, for talent '{Talent}'.", skillId, talent);
        }
      }
    }
    talent.SetSkill(skill);

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
}
