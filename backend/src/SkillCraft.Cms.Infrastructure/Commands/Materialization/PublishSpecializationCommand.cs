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
    SpecializationEntity? specialization = await _context.Specializations
      .Include(x => x.DiscountedTalents)
      .Include(x => x.Features)
      .Include(x => x.OptionalTalents)
      .SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (specialization is null)
    {
      specialization = new SpecializationEntity(command.Event);
      _context.Specializations.Add(specialization);
    }

    specialization.Slug = locale.GetString(Specializations.Slug);
    specialization.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    specialization.Tier = (int)invariant.GetNumber(Specializations.Tier);

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

    await SetOptionalTalentsAsync(specialization, invariant, cancellationToken);

    specialization.Summary = locale.TryGetString(Specializations.Summary);
    specialization.MetaDescription = locale.Description?.ToMetaDescription();
    specialization.Description = locale.TryGetString(Specializations.HtmlContent);

    specialization.OtherRequirements = locale.TryGetString(Specializations.OtherRequirements);
    specialization.OtherOptions = locale.TryGetString(Specializations.OtherOptions);

    specialization.ReservedTalentName = locale.TryGetString(Specializations.ReservedTalentName);
    specialization.ReservedTalentDescription = locale.TryGetString(Specializations.ReservedTalentHtmlContent);

    await SetDiscountedTalentsAsync(specialization, invariant, cancellationToken);
    await SetFeaturesAsync(specialization, invariant, cancellationToken);

    specialization.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The specialization '{Specialization}' has been published.", specialization);

    return new CommandResult();
  }

  private async Task SetDiscountedTalentsAsync(SpecializationEntity specialization, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> discountedTalentIds = invariant.GetRelatedContents(Specializations.DiscountedTalents);
    Dictionary<Guid, TalentEntity> discountedTalents = discountedTalentIds.Count < 1
      ? []
      : await _context.Talents.Where(x => discountedTalentIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

    foreach (SpecializationDiscountedTalentEntity discountedTalent in specialization.DiscountedTalents)
    {
      if (!discountedTalents.ContainsKey(discountedTalent.TalentUid))
      {
        _context.SpecializationDiscountedTalents.Remove(discountedTalent);
      }
    }

    HashSet<Guid> existingIds = specialization.DiscountedTalents.Select(x => x.TalentUid).ToHashSet();
    foreach (Guid discountedTalentId in discountedTalentIds)
    {
      if (discountedTalents.TryGetValue(discountedTalentId, out TalentEntity? talent))
      {
        if (!existingIds.Contains(discountedTalentId))
        {
          specialization.AddDiscountedTalent(talent);
        }
      }
      else
      {
        _logger.LogWarning("The discounted talent 'Id={DiscountedTalentId}' was not found, for specialization '{Specialization}'.", discountedTalentId, specialization);
      }
    }
  }

  private async Task SetFeaturesAsync(SpecializationEntity specialization, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> featureIds = invariant.GetRelatedContents(Specializations.Features);
    Dictionary<Guid, FeatureEntity> features = featureIds.Count < 1
      ? []
      : await _context.Features.Where(x => featureIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

    foreach (SpecializationFeatureEntity feature in specialization.Features)
    {
      if (!features.ContainsKey(feature.FeatureUid))
      {
        _context.SpecializationFeatures.Remove(feature);
      }
    }

    HashSet<Guid> existingIds = specialization.Features.Select(x => x.FeatureUid).ToHashSet();
    foreach (Guid featureId in featureIds)
    {
      if (features.TryGetValue(featureId, out FeatureEntity? feature))
      {
        if (!existingIds.Contains(featureId))
        {
          specialization.AddFeature(feature);
        }
      }
      else
      {
        _logger.LogWarning("The feature 'Id={OptionalTalentId}' was not found, for specialization '{Specialization}'.", featureId, specialization);
      }
    }
  }

  private async Task SetOptionalTalentsAsync(SpecializationEntity specialization, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> optionalTalentIds = invariant.GetRelatedContents(Specializations.OptionalTalents);
    Dictionary<Guid, TalentEntity> optionalTalents = optionalTalentIds.Count < 1
      ? []
      : await _context.Talents.Where(x => optionalTalentIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

    foreach (SpecializationOptionalTalentEntity optionalTalent in specialization.OptionalTalents)
    {
      if (!optionalTalents.ContainsKey(optionalTalent.TalentUid))
      {
        _context.SpecializationOptionalTalents.Remove(optionalTalent);
      }
    }

    HashSet<Guid> existingIds = specialization.OptionalTalents.Select(x => x.TalentUid).ToHashSet();
    foreach (Guid optionalTalentId in optionalTalentIds)
    {
      if (optionalTalents.TryGetValue(optionalTalentId, out TalentEntity? talent))
      {
        if (!existingIds.Contains(optionalTalentId))
        {
          specialization.AddOptionalTalent(talent);
        }
      }
      else
      {
        _logger.LogWarning("The optional talent 'Id={OptionalTalentId}' was not found, for specialization '{Specialization}'.", optionalTalentId, specialization);
      }
    }
  }
}
