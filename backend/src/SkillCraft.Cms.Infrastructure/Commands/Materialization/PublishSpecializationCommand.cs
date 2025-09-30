using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishSpecializationCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishSpecializationCommandHandler : ICommandHandler<PublishSpecializationCommand, CommandResult>
{
  private readonly RulesContext _context;
  private readonly ILogger<PublishSpecializationCommandHandler> _logger;

  public PublishSpecializationCommandHandler(RulesContext context, ILogger<PublishSpecializationCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishSpecializationCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    SpecializationEntity? specialization = await _context.Specializations.SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (specialization is null)
    {
      specialization = new SpecializationEntity(command.Event);
      _context.Specializations.Add(specialization);
    }

    specialization.Slug = locale.GetString(Specializations.Slug);
    specialization.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    specialization.Tier = (int)locale.GetNumber(Specializations.Tier);

    TalentEntity? mandatoryTalent = null;
    IReadOnlyCollection<Guid>? mandatoryTalentIds = invariant.TryGetRelatedContents(Specializations.MandatoryTalent);
    if (mandatoryTalentIds is not null)
    {
      if (mandatoryTalentIds.Count > 1)
      {
        _logger.LogWarning("Many mandatory talents ({Count}) were provided, when at most one is expected, for specialization '{Specialization}'.", mandatoryTalentIds.Count, specialization);
      }
      else if (mandatoryTalentIds.Count == 1)
      {
        Guid mandatoryTalentId = mandatoryTalentIds.Single();
        mandatoryTalent = await _context.Talents.SingleOrDefaultAsync(x => x.Id == mandatoryTalentId, cancellationToken);
        if (mandatoryTalent is null)
        {
          _logger.LogWarning("The mandatory talent 'Id={MandatoryTalentId}' was not found, for specialization '{Specialization}'.", mandatoryTalentId, specialization);
        }
      }
    }
    specialization.SetMandatoryTalent(mandatoryTalent);

    specialization.OptionalTalents.Clear();
    IReadOnlyCollection<Guid>? optionalTalentIds = invariant.TryGetRelatedContents(Specializations.OptionalTalents);
    if (optionalTalentIds is not null)
    {
      Dictionary<Guid, TalentEntity> optionalTalents = await _context.Talents
        .Where(x => optionalTalentIds.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

      specialization.OptionalTalents.AddRange(optionalTalents.Values);

      foreach (Guid optionalTalentId in optionalTalentIds)
      {
        if (!optionalTalents.ContainsKey(optionalTalentId))
        {
          _logger.LogWarning("The optional talent 'Id={OptionalTalentId}' was not found, for specialization '{Specialization}'.", optionalTalentId, specialization);
        }
      }
    }

    specialization.Summary = locale.TryGetString(Specializations.Summary);
    specialization.Description = locale.TryGetString(Specializations.HtmlContent);

    specialization.OtherRequirements = locale.TryGetString(Specializations.OtherRequirements);
    specialization.OtherOptions = locale.TryGetString(Specializations.OtherOptions);

    specialization.ReservedTalentName = locale.GetString(Specializations.ReservedTalentName);
    specialization.ReservedTalentDescription = locale.TryGetString(Specializations.ReservedTalentHtmlContent);

    specialization.DiscountedTalents.Clear();
    IReadOnlyCollection<Guid>? discountedTalentIds = invariant.TryGetRelatedContents(Specializations.DiscountedTalents);
    if (discountedTalentIds is not null)
    {
      Dictionary<Guid, TalentEntity> discountedTalents = await _context.Talents
        .Where(x => discountedTalentIds.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

      specialization.OptionalTalents.AddRange(discountedTalents.Values);

      foreach (Guid optionalTalentId in discountedTalentIds)
      {
        if (!discountedTalents.ContainsKey(optionalTalentId))
        {
          _logger.LogWarning("The discounted talent 'Id={OptionalTalentId}' was not found, for specialization '{Specialization}'.", optionalTalentId, specialization);
        }
      }
    }

    specialization.Features.Clear();
    IReadOnlyCollection<Guid>? featureIds = invariant.TryGetRelatedContents(Specializations.Features);
    if (featureIds is not null)
    {
      Dictionary<Guid, FeatureEntity> features = await _context.Features
        .Where(x => featureIds.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

      specialization.Features.AddRange(features.Values);

      foreach (Guid featureId in featureIds)
      {
        if (!features.ContainsKey(featureId))
        {
          _logger.LogWarning("The feature 'Id={FeatureId}' was not found, for specialization '{Specialization}'.", featureId, specialization);
        }
      }
    }

    specialization.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The specialization '{Specialization}' has been published.", specialization);

    return new CommandResult();
  }
}
