using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishEducationCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishEducationCommandHandler : ICommandHandler<PublishEducationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishEducationCommandHandler> _logger;

  public PublishEducationCommandHandler(RulesContext context, ILogger<PublishEducationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishEducationCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    EducationEntity? education = await _context.Educations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (education is null)
    {
      education = new EducationEntity(command.Event);
      _context.Educations.Add(education);
    }

    education.Slug = locale.GetString(Educations.Slug);
    education.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    double? wealthMultiplier = invariant.TryGetNumber(Educations.WealthMultiplier);
    education.WealthMultiplier = wealthMultiplier.HasValue ? (int)wealthMultiplier.Value : null;

    SkillEntity? skill = null;
    IReadOnlyCollection<Guid>? skillIds = invariant.TryGetRelatedContents(Educations.Skill);
    if (skillIds is not null)
    {
      if (skillIds.Count > 1)
      {
        _logger.LogWarning("Many skills ({Count}) were provided, when at most one is expected, for education '{Education}'.", skillIds.Count, education);
      }
      else if (skillIds.Count == 1)
      {
        Guid skillId = skillIds.Single();
        skill = await _context.Skills.SingleOrDefaultAsync(x => x.Id == skillId, cancellationToken);
        if (skill is null)
        {
          _logger.LogWarning("The skill 'Id={SkillId}' was not found, for education '{Education}'.", skillId, education);
        }
      }
    }
    education.SetSkill(skill);

    FeatureEntity? feature = null;
    IReadOnlyCollection<Guid>? featureIds = invariant.TryGetRelatedContents(Educations.Feature);
    if (featureIds is not null)
    {
      if (featureIds.Count > 1)
      {
        _logger.LogWarning("Many features ({Count}) were provided, when at most one is expected, for education '{Education}'.", featureIds.Count, education);
      }
      else if (featureIds.Count == 1)
      {
        Guid featureId = featureIds.Single();
        feature = await _context.Features.SingleOrDefaultAsync(x => x.Id == featureId, cancellationToken);
        if (feature is null)
        {
          _logger.LogWarning("The feature 'Id={FeatureId}' was not found, for education '{Education}'.", featureId, education);
        }
      }
    }
    education.SetFeature(feature);

    education.Summary = locale.TryGetString(Educations.Summary);
    education.MetaDescription = locale.Description?.ToMetaDescription();
    education.Description = locale.TryGetString(Educations.HtmlContent);

    education.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The education '{Education}' has been published.", education);

    return new CommandResult();
  }
}
