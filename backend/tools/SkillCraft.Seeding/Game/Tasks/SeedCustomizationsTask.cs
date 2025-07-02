using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using MediatR;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Data;
using SkillCraft.Seeding.Game.Payloads;

namespace SkillCraft.Seeding.Game.Tasks;

internal class SeedCustomizationsTask : SeedingTask
{
  public override string? Description => "Seeds the customization contents into Krakenar.";
  public string Language { get; }

  public SeedCustomizationsTask(string language)
  {
    Language = language;
  }
}

internal class SeedCustomizationsTaskHandler : INotificationHandler<SeedCustomizationsTask>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedCustomizationsTaskHandler> _logger;

  public SeedCustomizationsTaskHandler(IContentService contentService, ILogger<SeedCustomizationsTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task Handle(SeedCustomizationsTask task, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Game/data/customizations.json", Encoding.UTF8, cancellationToken);
    IEnumerable<CustomizationPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<CustomizationPayload>>(json);
    if (payloads is not null)
    {
      SearchContentLocalesPayload search = new()
      {
        ContentTypeId = Customizations.ContentTypeId
      };
      SearchResults<ContentLocale> invariants = await _contentService.SearchLocalesAsync(search, cancellationToken);
      HashSet<Guid> existingIds = invariants.Items.Select(x => x.Content.Id).ToHashSet();

      foreach (CustomizationPayload customization in payloads)
      {
        string kind = SeedingSerializer.Serialize<CustomizationKind[]>([customization.Kind]);

        Content content;
        if (existingIds.Contains(customization.Id))
        {
          SaveContentLocalePayload invariant = new()
          {
            UniqueName = customization.Slug,
            DisplayName = customization.Name,
            Description = customization.Notes
          };
          invariant.FieldValues.Add(new FieldValuePayload(Customizations.Kind.ToString(), kind));
          _ = await _contentService.SaveLocaleAsync(customization.Id, invariant, language: null, cancellationToken);

          SaveContentLocalePayload locale = new()
          {
            UniqueName = customization.Slug,
            DisplayName = customization.Name,
            Description = customization.Notes
          };
          locale.FieldValues.Add(new FieldValuePayload(Customizations.Slug.ToString(), customization.Slug));
          locale.FieldValues.Add(new FieldValuePayload(Customizations.Summary.ToString(), customization.Summary ?? string.Empty));
          locale.FieldValues.Add(new FieldValuePayload(Customizations.Description.ToString(), customization.Description ?? string.Empty));
          content = await _contentService.SaveLocaleAsync(customization.Id, locale, task.Language, cancellationToken)
            ?? throw new InvalidOperationException($"The content 'Id={customization.Id}' was not found.");

          _logger.LogInformation("The customization '{Customization}' was updated.", customization.Name);
        }
        else
        {
          CreateContentPayload payload = new()
          {
            Id = customization.Id,
            ContentType = Customizations.ContentTypeId.ToString(),
            Language = task.Language,
            UniqueName = customization.Slug,
            DisplayName = customization.Name,
            Description = customization.Notes
          };
          payload.FieldValues.Add(new FieldValuePayload(Customizations.Kind.ToString(), kind));
          payload.FieldValues.Add(new FieldValuePayload(Customizations.Slug.ToString(), customization.Slug));
          payload.FieldValues.Add(new FieldValuePayload(Customizations.Summary.ToString(), customization.Summary ?? string.Empty));
          payload.FieldValues.Add(new FieldValuePayload(Customizations.Description.ToString(), customization.Description ?? string.Empty));
          content = await _contentService.CreateAsync(payload, cancellationToken);
          _logger.LogInformation("The customization '{Customization}' was created.", customization.Name);
        }

        _ = await _contentService.PublishAsync(customization.Id, language: null, cancellationToken);
        _ = await _contentService.PublishAsync(customization.Id, task.Language, cancellationToken);
        _logger.LogInformation("The customization '{Customization}' was published.", customization.Name);
      }
    }
  }
}
