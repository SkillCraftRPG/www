using Krakenar.Contracts.Contents;
using Krakenar.Contracts.Fields;
using Krakenar.Contracts.Search;
using Krakenar.Core;
using Krakenar.Core.Contents;
using SkillCraft.Cms.Core.Progress.Models;

namespace SkillCraft.Cms.Core.Progress.Queries;

internal record ReadProgress : IQuery<ProgressModel>;

internal class ReadProgressHandler : IQueryHandler<ReadProgress, ProgressModel>
{
  private static readonly Dictionary<Guid, Action<ProgressModel, FieldValue>> _handlers = new()
  {
    [ProgressType.Characters] = (progress, field) => progress.Characters = Parse(field.Value),
    [ProgressType.Attributes] = (progress, field) => progress.Attributes = Parse(field.Value),
    [ProgressType.Statistics] = (progress, field) => progress.Statistics = Parse(field.Value),
    [ProgressType.Skills] = (progress, field) => progress.Skills = Parse(field.Value),
    [ProgressType.Lineages] = (progress, field) => progress.Lineages = Parse(field.Value),
    [ProgressType.Customizations] = (progress, field) => progress.Customizations = Parse(field.Value),
    [ProgressType.Castes] = (progress, field) => progress.Castes = Parse(field.Value),
    [ProgressType.Educations] = (progress, field) => progress.Educations = Parse(field.Value),
    [ProgressType.Talents] = (progress, field) => progress.Talents = Parse(field.Value),
    [ProgressType.Specializations] = (progress, field) => progress.Specializations = Parse(field.Value),
    [ProgressType.Languages] = (progress, field) => progress.Languages = Parse(field.Value),
    [ProgressType.Equipment] = (progress, field) => progress.Equipment = Parse(field.Value),
    [ProgressType.Adventure] = (progress, field) => progress.Adventure = Parse(field.Value),
    [ProgressType.Combat] = (progress, field) => progress.Combat = Parse(field.Value),
    [ProgressType.Magic] = (progress, field) => progress.Magic = Parse(field.Value),
    [ProgressType.Annexes] = (progress, field) => progress.Annexes = Parse(field.Value)
  };

  private readonly IPublishedContentQuerier _publishedContentQuerier;

  public ReadProgressHandler(IPublishedContentQuerier publishedContentQuerier)
  {
    _publishedContentQuerier = publishedContentQuerier;
  }

  public async Task<ProgressModel> HandleAsync(ReadProgress query, CancellationToken cancellationToken)
  {
    SearchPublishedContentsPayload payload = new();
    payload.ContentType.Uids.Add(ProgressType.ContentTypeId);
    SearchResults<PublishedContentLocale> locales = await _publishedContentQuerier.SearchAsync(payload, cancellationToken);
    PublishedContentLocale locale = locales.Items.Single();

    ProgressModel progress = new();
    foreach (FieldValue fieldValue in locale.FieldValues)
    {
      if (_handlers.TryGetValue(fieldValue.Id, out Action<ProgressModel, FieldValue>? handler))
      {
        handler(progress, fieldValue);
      }
    }
    return progress;
  }

  private static double Parse(string value)
  {
    value = value.Split('=').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).Last();
    if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double progress) && progress > 0)
    {
      return progress > 1 ? 1 : progress;
    }
    return 0;
  }
}
