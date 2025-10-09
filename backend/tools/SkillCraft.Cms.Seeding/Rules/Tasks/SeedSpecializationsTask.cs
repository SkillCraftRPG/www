using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Core;
using SkillCraft.Cms.Core.Features.Models;
using SkillCraft.Cms.Core.Specializations;
using SkillCraft.Cms.Core.Specializations.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedSpecializationsTask : SeedingTask
{
  public override string? Description => "Seeds the Specializations contents.";
}

internal class SeedSpecializationsTaskHandler : ICommandHandler<SeedSpecializationsTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly IFeatureService _featureService;
  private readonly ILogger<SeedSpecializationsTaskHandler> _logger;
  private readonly ISpecializationQuerier _specializationQuerier;

  public SeedSpecializationsTaskHandler(
    IContentService contentService,
    DefaultSettings defaults,
    IFeatureService featureService,
    ILogger<SeedSpecializationsTaskHandler> logger,
    ISpecializationQuerier specializationQuerier)
  {
    _contentService = contentService;
    _defaults = defaults;
    _featureService = featureService;
    _logger = logger;
    _specializationQuerier = specializationQuerier;
  }

  public async Task<TaskResult> HandleAsync(SeedSpecializationsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/specializations.json", Encoding.UTF8, cancellationToken);
    SpecializationDto[] entities = SeedingSerializer.Deserialize<SpecializationDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Specializations} specialization(s).", entities.Length);

    if (entities.Length > 0)
    {
      foreach (SpecializationDto entity in entities)
      {
        SpecializationModel? specialization = await _specializationQuerier.ReadAsync(entity.Id, cancellationToken);
        if (specialization is null || HasChanges(specialization, entity))
        {
          if (entity.ReservedTalent is not null)
          {
            foreach (FeatureDto feature in entity.ReservedTalent.Features)
            {
              await _featureService.SeedAsync(feature, entity.Name, cancellationToken);
            }
          }

          Content content;
          if (specialization is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Specializations.ContentTypeId.ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            payload.FieldValues.AddRange(GetInvariantFieldValues(entity));
            payload.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.CreateAsync(payload, cancellationToken);
          }
          else
          {
            SaveContentLocalePayload invariant = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name
            };
            invariant.FieldValues.AddRange(GetInvariantFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The specialization content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            locale.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The specialization content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Specialization '{Specialization}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Specialization '{Specialization}' has no change.", specialization);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(SpecializationModel specialization, SpecializationDto entity) => specialization.Slug != entity.Slug
    || specialization.Name != entity.Name
    || specialization.Tier != entity.Tier
    || specialization.Summary != entity.Summary
    || specialization.MetaDescription != entity.MetaDescription
    || specialization.Description != entity.Description
    || specialization.Requirements.Talent?.Id != entity.Requirements.Talent?.Id
    || !specialization.Requirements.Other.SequenceEqual(entity.Requirements.Other)
    || !specialization.Options.Talents.Select(x => x.Id).OrderBy(x => x).SequenceEqual(entity.Options.Talents.Select(x => x.Id).OrderBy(x => x))
    || !specialization.Options.Other.SequenceEqual(entity.Options.Other)
    || specialization.ReservedTalent?.Name != entity.ReservedTalent?.Name
    || !(specialization.ReservedTalent?.Description ?? []).SequenceEqual(entity.ReservedTalent?.Description ?? [])
    || !(specialization.ReservedTalent?.DiscountedTalents.Select(x => x.Id).OrderBy(x => x).ToArray() ?? [])
      .SequenceEqual(entity.ReservedTalent?.DiscountedTalents.Select(x => x.Id).OrderBy(x => x).ToArray() ?? [])
    || !(specialization.ReservedTalent?.Features.Select(Encode).OrderBy(x => x).ToArray() ?? [])
      .SequenceEqual(entity.ReservedTalent?.Features.Select(Encode).OrderBy(x => x).ToArray() ?? []);
  private static string Encode(FeatureDto feature) => string.IsNullOrWhiteSpace(feature.Description) ? feature.Name : string.Join('|', feature.Name, feature.Description);
  private static string Encode(FeatureModel feature) => string.IsNullOrWhiteSpace(feature.Description) ? feature.Name : string.Join('|', feature.Name, feature.Description);

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(SpecializationDto specialization)
  {
    List<FieldValuePayload> payloads = new(capacity: 5)
    {
      new FieldValuePayload(Specializations.Tier.ToString(), specialization.Tier.ToString())
    };
    if (specialization.Requirements.Talent is not null)
    {
      string value = SeedingSerializer.Serialize<Guid[]>([specialization.Requirements.Talent.Id]);
      payloads.Add(new FieldValuePayload(Specializations.MandatoryTalent.ToString(), value));
    }
    if (specialization.Options.Talents.Count > 0)
    {
      string value = SeedingSerializer.Serialize(specialization.Options.Talents.Select(x => x.Id));
      payloads.Add(new FieldValuePayload(Specializations.OptionalTalents.ToString(), value));
    }
    if (specialization.ReservedTalent is not null)
    {
      if (specialization.ReservedTalent.DiscountedTalents.Count > 0)
      {
        string value = SeedingSerializer.Serialize(specialization.ReservedTalent.DiscountedTalents.Select(x => x.Id));
        payloads.Add(new FieldValuePayload(Specializations.DiscountedTalents.ToString(), value));
      }
      if (specialization.ReservedTalent.Features.Count > 0)
      {
        string value = SeedingSerializer.Serialize(specialization.ReservedTalent.Features.Select(x => x.Id));
        payloads.Add(new FieldValuePayload(Specializations.Features.ToString(), value));
      }
    }
    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(SpecializationDto specialization)
  {
    List<FieldValuePayload> payloads = new(capacity: 7)
    {
      new FieldValuePayload(Specializations.Slug.ToString(), specialization.Slug)
    };
    if (!string.IsNullOrWhiteSpace(specialization.Summary))
    {
      payloads.Add(new FieldValuePayload(Specializations.Summary.ToString(), specialization.Summary));
    }
    if (!string.IsNullOrWhiteSpace(specialization.Description))
    {
      payloads.Add(new FieldValuePayload(Specializations.HtmlContent.ToString(), specialization.Description));
    }
    if (specialization.Requirements.Other.Count > 0)
    {
      string value = string.Join('\n', specialization.Requirements.Other);
      payloads.Add(new FieldValuePayload(Specializations.OtherRequirements.ToString(), value));
    }
    if (specialization.Options.Other.Count > 0)
    {
      string value = string.Join('\n', specialization.Options.Other);
      payloads.Add(new FieldValuePayload(Specializations.OtherOptions.ToString(), value));
    }
    if (specialization.ReservedTalent is not null)
    {
      payloads.Add(new FieldValuePayload(Specializations.ReservedTalentName.ToString(), specialization.ReservedTalent.Name));
      if (specialization.ReservedTalent.Description.Count > 0)
      {
        string value = string.Join('\n', specialization.ReservedTalent.Description);
        payloads.Add(new FieldValuePayload(Specializations.ReservedTalentHtmlContent.ToString(), value));
      }
    }
    return payloads.AsReadOnly();
  }
}
