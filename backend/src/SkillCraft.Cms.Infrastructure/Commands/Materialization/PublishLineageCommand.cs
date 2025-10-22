using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Logitar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Cms.Infrastructure.Contents;
using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Infrastructure.Commands.Materialization;

internal record PublishLineageCommand(ContentLocalePublished Event, ContentLocale Invariant, ContentLocale Locale) : ICommand<CommandResult>;

internal class PublishLineageCommandHandler : ICommandHandler<PublishLineageCommand, CommandResult>
{
  private const char Separator = ',';

  private readonly RulesContext _context;
  private readonly ILogger<PublishLineageCommandHandler> _logger;

  public PublishLineageCommandHandler(RulesContext context, ILogger<PublishLineageCommandHandler> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<CommandResult> HandleAsync(PublishLineageCommand command, CancellationToken cancellationToken)
  {
    ContentLocalePublished @event = command.Event;
    ContentLocale invariant = command.Invariant;
    ContentLocale locale = command.Locale;

    string streamId = @event.StreamId.Value;
    LineageEntity? lineage = await _context.Lineages
      .Include(x => x.Parent)
      .Include(x => x.Features)
      .Include(x => x.Languages)
      .SingleOrDefaultAsync(x => x.StreamId == streamId, cancellationToken);
    if (lineage is null)
    {
      lineage = new LineageEntity(command.Event);
      _context.Lineages.Add(lineage);
    }

    lineage.Slug = locale.GetString(Lineages.Slug);
    lineage.Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;

    lineage.ExtraLanguages = (int)invariant.GetNumber(Lineages.ExtraLanguages);
    lineage.LanguagesText = locale.TryGetString(Lineages.LanguagesText);

    SetNames(lineage, locale);

    SetSpeed(lineage, invariant);

    SizeCategory sizeCategory = SizeCategory.Medium;
    IReadOnlyCollection<string> sizeCategories = invariant.GetSelect(Lineages.SizeCategory);
    if (sizeCategories.Count > 1)
    {
      _logger.LogWarning("Many size categories ({Count}) were provided, when at most one is expected, for lineage '{Lineage}'.", sizeCategories.Count, lineage);
    }
    else if (sizeCategories.Count == 1)
    {
      string sizeCategoryValue = sizeCategories.Single();
      if (!Enum.TryParse(sizeCategoryValue, ignoreCase: true, out sizeCategory))
      {
        _logger.LogWarning("The size category '{SizeCategory}' is not valid for lineage '{Lineage}'.", sizeCategoryValue, lineage);
      }
    }
    lineage.SizeCategory = sizeCategory;
    lineage.SizeRoll = invariant.TryGetString(Lineages.SizeRoll);
    SetWeight(lineage, invariant);
    SetAge(lineage, invariant);

    lineage.Summary = locale.TryGetString(Lineages.Summary);
    lineage.MetaDescription = locale.Description?.ToMetaDescription();
    lineage.Description = locale.TryGetString(Lineages.HtmlContent);

    await SetParentAsync(lineage, invariant, cancellationToken);
    await SetFeaturesAsync(lineage, invariant, cancellationToken);
    await SetLanguagesAsync(lineage, invariant, cancellationToken);

    lineage.Publish(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogInformation("The lineage '{Lineage}' has been published.", lineage);

    return new CommandResult();
  }

  private void SetAge(LineageEntity lineage, ContentLocale invariant)
  {
    string? value = invariant.TryGetString(Lineages.Age);
    if (!string.IsNullOrWhiteSpace(value))
    {
      int[] values = value.Split(Separator).Select(value => int.TryParse(value, out int parsed) ? parsed : 0).ToArray();
      if (values.Length == 4 && values.All(value => value > 0) && values.SequenceEqual(values.OrderBy(x => x)))
      {
        lineage.Adolescent = values[0];
        lineage.Adult = values[1];
        lineage.Mature = values[2];
        lineage.Venerable = values[3];
        return;
      }
      else
      {
        _logger.LogWarning("The lineage age '{Age}' is not valid for lineage '{Lineage}'.", value, lineage);
      }
    }

    lineage.Adolescent = 0;
    lineage.Adult = 0;
    lineage.Mature = 0;
    lineage.Venerable = 0;
  }

  private async Task SetFeaturesAsync(LineageEntity lineage, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> featureIds = invariant.GetRelatedContents(Lineages.Features);
    Dictionary<Guid, FeatureEntity> features = featureIds.Count < 1
      ? []
      : await _context.Features.Where(x => featureIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

    foreach (LineageFeatureEntity feature in lineage.Features)
    {
      if (!features.ContainsKey(feature.FeatureUid))
      {
        _context.LineageFeatures.Remove(feature);
      }
    }

    HashSet<Guid> existingIds = lineage.Features.Select(x => x.FeatureUid).ToHashSet();
    foreach (Guid featureId in featureIds)
    {
      if (features.TryGetValue(featureId, out FeatureEntity? feature))
      {
        if (!existingIds.Contains(featureId))
        {
          lineage.AddFeature(feature);
        }
      }
      else
      {
        _logger.LogWarning("The feature 'Id={FeatureId}' was not found, for lineage '{Lineage}'.", featureId, lineage);
      }
    }
  }

  private async Task SetLanguagesAsync(LineageEntity lineage, ContentLocale invariant, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<Guid> languageIds = invariant.GetRelatedContents(Lineages.Languages);
    Dictionary<Guid, LanguageEntity> languages = languageIds.Count < 1
      ? []
      : await _context.Languages.Where(x => languageIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, x => x, cancellationToken);

    foreach (LineageLanguageEntity language in lineage.Languages)
    {
      if (!languages.ContainsKey(language.LanguageUid))
      {
        _context.LineageLanguages.Remove(language);
      }
    }

    HashSet<Guid> existingIds = lineage.Languages.Select(x => x.LanguageUid).ToHashSet();
    foreach (Guid languageId in languageIds)
    {
      if (languages.TryGetValue(languageId, out LanguageEntity? language))
      {
        if (!existingIds.Contains(languageId))
        {
          lineage.AddLanguage(language);
        }
      }
      else
      {
        _logger.LogWarning("The language 'Id={LanguageId}' was not found, for lineage '{Lineage}'.", languageId, lineage);
      }
    }
  }

  private void SetNames(LineageEntity lineage, ContentLocale locale)
  {
    NamesModel names = new()
    {
      Text = locale.TryGetString(Lineages.NamesText)
    };

    string? namesSelection = locale.TryGetString(Lineages.NamesSelection);
    if (!string.IsNullOrWhiteSpace(namesSelection))
    {
      string[] lines = namesSelection.Remove("\r").Split('\n');
      foreach (string line in lines)
      {
        if (!string.IsNullOrWhiteSpace(line))
        {
          string[] parts = line.Split(':');
          if (parts.Length == 2 || string.IsNullOrWhiteSpace(parts.First()))
          {
            string category = parts.First().Trim();
            string[] values = parts.Last().Split(Separator).Where(name => !string.IsNullOrWhiteSpace(name)).Select(name => name.Trim()).OrderBy(name => name).ToArray();
            if (values.Length < 1)
            {
              _logger.LogWarning("The name category '{Category}' is being ignored because its empty for lineage '{Lineage}'.", category, lineage);
            }
            else
            {
              switch (category.ToLowerInvariant())
              {
                case "family":
                  names.Family.Clear();
                  names.Family.AddRange(values);
                  break;
                case "female":
                  names.Female.Clear();
                  names.Female.AddRange(values);
                  break;
                case "male":
                  names.Male.Clear();
                  names.Male.AddRange(values);
                  break;
                case "unisex":
                  names.Unisex.Clear();
                  names.Unisex.AddRange(values);
                  break;
                default:
                  NameCategory? nameCategory = names.Custom.SingleOrDefault(x => x.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase));
                  if (nameCategory is null)
                  {
                    nameCategory = new NameCategory(category, values);
                    names.Custom.Add(nameCategory);
                  }
                  else
                  {
                    nameCategory.Values.Clear();
                    nameCategory.Values.AddRange(values);
                  }
                  break;
              }
            }
          }
          else
          {
            _logger.LogWarning("The name category '{Category}' is not valid for lineage '{Lineage}'.", line, lineage);
          }
        }
      }
    }

    lineage.SetNames(names);
  }

  private async Task SetParentAsync(LineageEntity lineage, ContentLocale invariant, CancellationToken cancellationToken)
  {
    LineageEntity? parent = null;

    IReadOnlyCollection<Guid> parentIds = invariant.GetRelatedContents(Lineages.Parent);
    if (parentIds.Count > 1)
    {
      _logger.LogWarning("Many parent lineage ({Count}) were provided, when at most one is expected, for lineage '{Lineage}'.", parentIds.Count, lineage);
    }
    else if (parentIds.Count == 1)
    {
      Guid parentId = parentIds.Single();
      if (parentId == lineage.Parent?.Id)
      {
        parent = lineage.Parent;
      }
      else
      {
        parent = await _context.Lineages.SingleOrDefaultAsync(x => x.Id == parentId, cancellationToken);
        if (parent is null)
        {
          _logger.LogWarning("The parent lineage 'Id={ParentLineageId}' was not found, for lineage '{Lineage}'.", parentId, lineage);
        }
      }
    }

    lineage.SetParent(parent);
  }

  private void SetSpeed(LineageEntity lineage, ContentLocale invariant)
  {
    string? value = invariant.TryGetString(Lineages.Speeds);
    if (string.IsNullOrWhiteSpace(value))
    {
      lineage.Walk = 0;
      lineage.Climb = 0;
      lineage.Swim = 0;
      lineage.Fly = 0;
      lineage.Hover = false;
      lineage.Burrow = 0;
    }
    else
    {
      string[] values = value.Split(Separator);
      foreach (string raw in values)
      {
        string[] parts = raw.Split(':');
        bool isHover = parts.First().Equals(nameof(LineageEntity.Hover), StringComparison.InvariantCultureIgnoreCase);
        if (parts.Length == 2
          && (Enum.TryParse(parts.First(), ignoreCase: true, out SpeedKind kind) || isHover)
          && int.TryParse(parts.Last(), out int speed) && speed >= 0)
        {
          if (isHover)
          {
            lineage.Fly = speed;
            lineage.Hover = true;
          }
          else
          {
            switch (kind)
            {
              case SpeedKind.Burrow:
                lineage.Burrow = speed;
                break;
              case SpeedKind.Climb:
                lineage.Climb = speed;
                break;
              case SpeedKind.Fly:
                lineage.Fly = speed;
                lineage.Hover = false;
                break;
              case SpeedKind.Swim:
                lineage.Swim = speed;
                break;
              case SpeedKind.Walk:
                lineage.Walk = speed;
                break;
            }
          }
        }
        else
        {
          _logger.LogWarning("The speed '{Speed}' is not valid for lineage '{Lineage}'.", raw, lineage);
        }
      }
    }
  }

  private void SetWeight(LineageEntity lineage, ContentLocale invariant)
  {
    string? value = invariant.TryGetString(Lineages.Weight);
    if (!string.IsNullOrWhiteSpace(value))
    {
      string[] values = value.Split(Separator);
      if (values.Length == 5)
      {
        lineage.Malnutrition = values[0].CleanTrim();
        lineage.Skinny = values[1].CleanTrim();
        lineage.NormalWeight = values[2].CleanTrim();
        lineage.Overweight = values[3].CleanTrim();
        lineage.Obese = values[4].CleanTrim();
        return;
      }
      else
      {
        _logger.LogWarning("The lineage weight '{Weight}' is not valid for lineage '{Lineage}'.", value, lineage);
      }
    }

    lineage.Malnutrition = null;
    lineage.Skinny = null;
    lineage.NormalWeight = null;
    lineage.Overweight = null;
    lineage.Obese = null;
  }
}
