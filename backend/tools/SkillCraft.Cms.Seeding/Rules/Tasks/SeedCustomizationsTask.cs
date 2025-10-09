using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Customizations;
using SkillCraft.Cms.Core.Customizations.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Contracts;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedCustomizationsTask : SeedingTask
{
  public override string? Description => "Seeds the Customizations contents.";
}

internal class SeedCustomizationsTaskHandler : ICommandHandler<SeedCustomizationsTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly ICustomizationQuerier _customizationQuerier;
  private readonly DefaultSettings _defaults;
  private readonly ILogger<SeedCustomizationsTaskHandler> _logger;

  public SeedCustomizationsTaskHandler(
    IContentService contentService,
    ICustomizationQuerier customizationQuerier,
    DefaultSettings defaults,
    ILogger<SeedCustomizationsTaskHandler> logger)
  {
    _contentService = contentService;
    _customizationQuerier = customizationQuerier;
    _defaults = defaults;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedCustomizationsTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/customizations.json", Encoding.UTF8, cancellationToken);
    CustomizationDto[] entities = SeedingSerializer.Deserialize<CustomizationDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Customizations} customization(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<CustomizationModel> results = await _customizationQuerier.SearchAsync(new SearchCustomizationsPayload(), cancellationToken);
      Dictionary<Guid, CustomizationModel> customizations = results.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Customizations} customization(s) from database.", customizations.Count);

      foreach (CustomizationDto entity in entities)
      {
        _ = customizations.TryGetValue(entity.Id, out CustomizationModel? customization);
        if (customization is null || HasChanges(customization, entity))
        {
          Content content;
          if (customization is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = GetContentTypeId(entity).ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
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
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The customization content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Slug,
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The customization content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Customization '{Customization}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Customization '{Customization}' has no change.", customization);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(CustomizationModel customization, CustomizationDto entity) => customization.Slug != entity.Slug
    || customization.Name != entity.Name
    || customization.Summary != entity.Summary
    || customization.MetaDescription != entity.MetaDescription
    || customization.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(CustomizationDto customization)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(GetSlugFieldId(customization).ToString(), customization.Slug)
    };
    if (!string.IsNullOrWhiteSpace(customization.Summary))
    {
      payloads.Add(new FieldValuePayload(GetSummaryFieldId(customization).ToString(), customization.Summary));
    }
    if (!string.IsNullOrWhiteSpace(customization.Description))
    {
      payloads.Add(new FieldValuePayload(GetHtmlContentFieldId(customization).ToString(), customization.Description));
    }
    return payloads.AsReadOnly();
  }

  private static Guid GetContentTypeId(CustomizationDto customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.ContentTypeId,
    CustomizationKind.Gift => Gifts.ContentTypeId,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
  private static Guid GetSlugFieldId(CustomizationDto customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.Slug,
    CustomizationKind.Gift => Gifts.Slug,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
  private static Guid GetSummaryFieldId(CustomizationDto customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.Summary,
    CustomizationKind.Gift => Gifts.Summary,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
  private static Guid GetHtmlContentFieldId(CustomizationDto customization) => customization.Kind switch
  {
    CustomizationKind.Disability => Disabilities.HtmlContent,
    CustomizationKind.Gift => Gifts.HtmlContent,
    _ => throw new NotSupportedException($"The customization kind '{customization.Kind}' is not supported."),
  };
}
