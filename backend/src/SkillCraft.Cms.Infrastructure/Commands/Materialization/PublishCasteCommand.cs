using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishCasteCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishCasteCommandHandler : ICommandHandler<PublishCasteCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishCasteCommandHandler> _logger;

  public PublishCasteCommandHandler(RulesContext context, ILogger<PublishCasteCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishCasteCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    CasteEntity? caste = await _context.Castes.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (caste is null)
    {
      caste = new CasteEntity(command.Event);
      _context.Castes.Add(caste);
    }

    caste.Slug = locale.GetString(Castes.Slug);
    caste.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    caste.WealthRoll = invariant.TryGetString(Castes.WealthRoll);

    SkillEntity? skill = null;
    IReadOnlyCollection<Guid>? skillIds = invariant.TryGetRelatedContents(Castes.Skill);
    if (skillIds is not null)
    {
      if (skillIds.Count > 1)
      {
        _logger.LogWarning("Many skills ({Count}) were provided, when at most one is expected, for caste '{Caste}'.", skillIds.Count, caste);
      }
      else if (skillIds.Count == 1)
      {
        Guid skillId = skillIds.Single();
        skill = await _context.Skills.SingleOrDefaultAsync(x => x.Id == skillId, cancellationToken);
        if (skill is null)
        {
          _logger.LogWarning("The skill 'Id={SkillId}' was not found, for caste '{Caste}'.", skillId, caste);
        }
      }
    }
    caste.SetSkill(skill);

    FeatureEntity? feature = null;
    IReadOnlyCollection<Guid>? featureIds = invariant.TryGetRelatedContents(Castes.Feature);
    if (featureIds is not null)
    {
      if (featureIds.Count > 1)
      {
        _logger.LogWarning("Many features ({Count}) were provided, when at most one is expected, for caste '{Caste}'.", featureIds.Count, caste);
      }
      else if (featureIds.Count == 1)
      {
        Guid featureId = featureIds.Single();
        feature = await _context.Features.SingleOrDefaultAsync(x => x.Id == featureId, cancellationToken);
        if (feature is null)
        {
          _logger.LogWarning("The feature 'Id={FeatureId}' was not found, for caste '{Caste}'.", featureId, caste);
        }
      }
    }
    caste.SetFeature(feature);

    caste.Summary = locale.TryGetString(Castes.Summary);
    caste.MetaDescription = locale.Description?.ToMetaDescription();
    caste.Description = locale.TryGetString(Castes.HtmlContent);

    caste.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The caste '{Caste}' has been published.", caste);

    return new CommandResult();
  }
}
