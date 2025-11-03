using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Languages;
using SkillCraft.Cms.Core.Languages.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class LanguageQuerier : ILanguageQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<LanguageEntity> _languages;
  private readonly ISqlHelper _sqlHelper;

  public LanguageQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _languages = context.Languages;
    _sqlHelper = sqlHelper;
  }

  public async Task<LanguageModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    LanguageEntity? language = await _languages.AsNoTracking()
      .Include(x => x.Script)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return language is null ? null : await MapAsync(language, cancellationToken);
  }
  public async Task<LanguageModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    LanguageEntity? language = await _languages.AsNoTracking()
      .Include(x => x.Script)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return language is null ? null : await MapAsync(language, cancellationToken);
  }

  public async Task<SearchResults<LanguageModel>> SearchAsync(SearchLanguagesPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Languages.Table).SelectAll(RulesDb.Languages.Table)
      .ApplyIdFilter(RulesDb.Languages.Id, payload.Ids)
      .Where(RulesDb.Languages.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Languages.Slug, RulesDb.Languages.Name, RulesDb.Languages.Summary);

    if (payload.ScriptId.HasValue)
    {
      builder.Where(RulesDb.Languages.ScriptUid, Operators.IsEqualTo(payload.ScriptId.Value));
    }

    IQueryable<LanguageEntity> query = _languages.FromQuery(builder).AsNoTracking()
      .Include(x => x.Script);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<LanguageEntity>? ordered = null;
    foreach (LanguageSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case LanguageSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case LanguageSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case LanguageSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case LanguageSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    LanguageEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<LanguageModel> languages = await MapAsync(entities, cancellationToken);

    return new SearchResults<LanguageModel>(languages, total);
  }

  private async Task<LanguageModel> MapAsync(LanguageEntity language, CancellationToken cancellationToken)
  {
    return (await MapAsync([language], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<LanguageModel>> MapAsync(IEnumerable<LanguageEntity> languages, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = languages.SelectMany(language => language.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return languages.Select(mapper.ToLanguage).ToList().AsReadOnly();
  }
}
