using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Seeding.Settings;
using SkillCraft.Tools.Shared.Models;

namespace SkillCraft.Cms.Seeding.Rules;

public interface IFeatureService
{
  Task SeedAsync(FeatureDto feature, CancellationToken cancellationToken = default);
  Task SeedAsync(FeatureDto feature, string? prefix, CancellationToken cancellationToken = default);
}

internal class FeatureService : IFeatureService
{
  private readonly IContentService _contentService;
  private readonly DefaultSettings _defaults;
  private readonly ILogger<FeatureService> _logger;

  public FeatureService(IContentService contentService, DefaultSettings defaults, ILogger<FeatureService> logger)
  {
    _contentService = contentService;
    _defaults = defaults;
    _logger = logger;
  }

  public async Task SeedAsync(FeatureDto feature, CancellationToken cancellationToken)
  {
    await SeedAsync(feature, prefix: null, cancellationToken);
  }
  public async Task SeedAsync(FeatureDto feature, string? prefix, CancellationToken cancellationToken)
  {
    Content? content = await _contentService.ReadAsync(feature.Id, cancellationToken);
    if (content is null || HasChanges(content, feature))
    {
      string uniqueName = FormatUniqueName(feature.Name, prefix);
      if (content is null)
      {
        CreateContentPayload payload = new()
        {
          Id = feature.Id,
          ContentType = Features.ContentTypeId.ToString(),
          Language = _defaults.Locale,
          UniqueName = uniqueName,
          DisplayName = feature.Name
        };
        payload.FieldValues.AddRange(GetLocaleFieldValues(feature));
        content = await _contentService.CreateAsync(payload, cancellationToken);
      }
      else
      {
        SaveContentLocalePayload invariant = new()
        {
          UniqueName = uniqueName,
          DisplayName = feature.Name
        };
        content = await _contentService.SaveLocaleAsync(feature.Id, invariant, language: null, cancellationToken)
          ?? throw new InvalidOperationException($"The feature content 'Id={feature.Id}' was not found.");

        SaveContentLocalePayload locale = new()
        {
          UniqueName = uniqueName,
          DisplayName = feature.Name
        };
        locale.FieldValues.AddRange(GetLocaleFieldValues(feature));
        content = await _contentService.SaveLocaleAsync(content.Id, locale, _defaults.Locale, cancellationToken)
          ?? throw new InvalidOperationException($"The feature content 'Id={feature.Id}' was not found.");
      }

      if (feature.IsPublished)
      {
        await _contentService.PublishAllAsync(content.Id, cancellationToken);
      }
      else
      {
        await _contentService.UnpublishAllAsync(content.Id, cancellationToken);
      }

      _logger.LogInformation("Feature '{Feature}' was seeded.", feature);
    }
    else
    {
      _logger.LogInformation("Feature '{Feature}' has no change.", feature);
    }
  }

  private bool HasChanges(Content content, FeatureDto feature)
  {
    ContentLocale? invariant = content.Locales.SingleOrDefault(l => l.Language is not null && l.Language.Locale.Code == _defaults.Locale);
    string? description = invariant?.FieldValues.SingleOrDefault(f => f.Id == Features.HtmlContent)?.Value;
    return invariant is null || invariant.DisplayName != feature.Name || description != feature.Description;
  }

  private static string FormatUniqueName(string name, string? prefix = null)
  {
    if (!string.IsNullOrWhiteSpace(prefix))
    {
      return string.Join('_', FormatUniqueName(prefix), FormatUniqueName(name));
    }

    List<string> words = new(capacity: name.Length);
    StringBuilder word = new();
    foreach (char c in name)
    {
      if (char.IsLetterOrDigit(c))
      {
        word.Append(c);
      }
      else if (word.Length > 0)
      {
        words.Add(word.ToString());
        word.Clear();
      }
    }
    if (word.Length > 0)
    {
      words.Add(word.ToString());
    }
    return string.Join("", words.Select(Format));
  }
  private static string Format(string s)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(s, nameof(s));
    s = Unaccent(s.Trim());

    return s.Length == 1 ? s.ToUpperInvariant() : string.Concat(s[..1].ToUpperInvariant(), s[1..].ToLowerInvariant());
  }

  private static readonly Dictionary<char, string> _accents = new()
  {
    ['Á'] = "A",
    ['À'] = "A",
    ['Â'] = "A",
    ['Ä'] = "A",
    ['á'] = "a",
    ['à'] = "a",
    ['â'] = "a",
    ['ä'] = "a",

    ['Ç'] = "C",
    ['ç'] = "c",

    ['É'] = "E",
    ['È'] = "E",
    ['Ê'] = "E",
    ['Ë'] = "E",
    ['é'] = "e",
    ['è'] = "e",
    ['ê'] = "e",
    ['ë'] = "e",

    ['Í'] = "I",
    ['Ì'] = "I",
    ['Î'] = "I",
    ['Ï'] = "I",
    ['í'] = "i",
    ['ì'] = "i",
    ['î'] = "i",
    ['ï'] = "i"
  };
  private static string Unaccent(string s)
  {
    StringBuilder result = new();
    foreach (char c in s)
    {
      if (!char.IsLetterOrDigit(c))
      {
        continue;
      }
      result.Append(_accents.TryGetValue(c, out string? replacement) ? replacement : c);
    }
    return result.ToString();
  }

  private static IReadOnlyCollection<FieldValuePayload> GetLocaleFieldValues(FeatureDto feature)
  {
    List<FieldValuePayload> payloads = new(capacity: 1);
    if (!string.IsNullOrWhiteSpace(feature.Description))
    {
      payloads.Add(new FieldValuePayload(Features.HtmlContent.ToString(), feature.Description));
    }
    return payloads.AsReadOnly();
  }
}
