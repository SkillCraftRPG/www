using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedAttributesTask : SeedingTask
{
  public override string? Description => "Seeds the Attributes contents.";
}

internal class SeedAttributesTaskHandler : ICommandHandler<SeedAttributesTask, TaskResult>
{
  private readonly IAttributeQuerier _attributeQuerier;
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly ILogger<SeedAttributesTaskHandler> _logger;

  public SeedAttributesTaskHandler(
    IAttributeQuerier attributeQuerier,
    IContentService contentService,
    DefaultSettings defaults,
    ILogger<SeedAttributesTaskHandler> logger)
  {
    _attributeQuerier = attributeQuerier;
    _contentService = contentService;
    _defaults = defaults;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedAttributesTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/attributes.json", Encoding.UTF8, cancellationToken);
    AttributeDto[] entities = SeedingSerializer.Deserialize<AttributeDto[]>(json) ?? [];
    _logger.LogInformation("Extracted {Attributes} attribute(s).", entities.Length);

    if (entities.Length > 0)
    {
      SearchResults<AttributeModel> results = await _attributeQuerier.SearchAsync(new SearchAttributesPayload(), cancellationToken);
      Dictionary<Guid, AttributeModel> attributes = results.Items.ToDictionary(x => x.Id, x => x);
      _logger.LogInformation("Retrieved {Attributes} attribute(s) from database.", attributes.Count);

      foreach (AttributeDto entity in entities)
      {
        _ = attributes.TryGetValue(entity.Id, out AttributeModel? attribute);
        if (attribute is null || HasChanges(attribute, entity))
        {
          Content content;
          if (attribute is null)
          {
            CreateContentPayload payload = new()
            {
              Id = entity.Id,
              ContentType = Attributes.ContentTypeId.ToString(),
              Language = _defaults.Locale,
              UniqueName = entity.Value.ToString(),
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
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name
            };
            invariant.FieldValues.AddRange(GetInvariantFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(entity.Id, invariant, language: null, cancellationToken)
              ?? throw new InvalidOperationException($"The attribute content 'Id={entity.Id}' was not found.");

            SaveContentLocalePayload locale = new()
            {
              UniqueName = entity.Value.ToString(),
              DisplayName = entity.Name,
              Description = entity.MetaDescription
            };
            invariant.FieldValues.AddRange(GetLocaleFieldValues(entity));
            content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
              ?? throw new InvalidOperationException($"The attribute content 'Id={entity.Id}' was not found.");
          }

          if (entity.IsPublished)
          {
            await _contentService.PublishAllAsync(content.Id, cancellationToken);
          }
          else
          {
            await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
          }

          _logger.LogInformation("Attribute '{Attribute}' was seeded.", entity);
        }
        else
        {
          _logger.LogInformation("Attribute '{Attribute}' has no change.", attribute);
        }
      }
    }

    return new TaskResult();
  }

  private static bool HasChanges(AttributeModel attribute, AttributeDto entity) => attribute.Slug != entity.Slug
    || attribute.Name != entity.Name
    || attribute.Category != entity.Category
    || attribute.Value != entity.Value
    || attribute.Summary != entity.Summary
    || attribute.MetaDescription != entity.MetaDescription
    || attribute.Description != entity.Description;

  private static IReadOnlyCollection<FieldValuePayload> GetInvariantFieldValues(AttributeDto attribute)
  {
    List<FieldValuePayload> payloads = new(capacity: 1);
    if (attribute.Category.HasValue)
    {
      string value = SeedingSerializer.Serialize<AttributeCategory[]>([attribute.Category.Value]);
      payloads.Add(new FieldValuePayload(Attributes.Category.ToString(), value));
    }
    return payloads.AsReadOnly();
  }
  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(AttributeDto attribute)
  {
    List<FieldValuePayload> payloads = new(capacity: 3)
    {
      new FieldValuePayload(Attributes.Slug.ToString(), attribute.Slug)
    };
    if (!string.IsNullOrWhiteSpace(attribute.Summary))
    {
      payloads.Add(new FieldValuePayload(Attributes.Summary.ToString(), attribute.Summary));
    }
    if (!string.IsNullOrWhiteSpace(attribute.Description))
    {
      payloads.Add(new FieldValuePayload(Attributes.HtmlContent.ToString(), attribute.Description));
    }
    return payloads.AsReadOnly();
  }
}
