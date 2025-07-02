using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedAttributesTask : SeedingTask
{
  public override string? Description => "Seeds the attribute contents into Krakenar.";
  public string Language { get; }

  public SeedAttributesTask(string language)
  {
    Language = language;
  }
}

internal class SeedAttributesTaskHandler : INotificationHandler<SeedAttributesTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedAttributesTaskHandler> _logger;

  public SeedAttributesTaskHandler(IContentService contentService, ILogger<SeedAttributesTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedAttributesTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/attributes.json", Encoding.UTF8, cancellationToken);
    IEnumerable<AttributePayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<AttributePayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Attributes.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (AttributePayload attribute in payloads)
      {
        Content content;
        if (existingIds.Contains(attribute.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = attribute.Value.ToString(),
            DisplayName = attribute.Name,
            Description = attribute.Notes
          };
          _ = await _contentService.SaveLocaleAsync(attribute.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = attribute.Value.ToString(),
            DisplayName = attribute.Name,
            Description = attribute.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Attributes.Slug.ToString(), attribute.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Attributes.Summary.ToString(), attribute.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Attributes.Description.ToString(), attribute.Description ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(attribute.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={attribute.Id}' was not found.");

          _logger.LogInformation("The attribute '{Attribute}' was updated.", attribute.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = attribute.Id,
            ContentType = Attributes.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = attribute.Value.ToString(),
            DisplayName = attribute.Name,
            Description = attribute.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Attributes.Slug.ToString(), attribute.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Attributes.Summary.ToString(), attribute.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Attributes.Description.ToString(), attribute.Description ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The attribute '{Attribute}' was created.", attribute.Name);
        }

        _ = await _contentService.PublishAsync(attribute.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(attribute.Id, task.Language, cancellationToken);
        _logger.LogInformation("The attribute '{Attribute}' was published.", attribute.Name);
      }
    }
  }
}
