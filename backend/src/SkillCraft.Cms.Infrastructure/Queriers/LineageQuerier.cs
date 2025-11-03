using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Lineages;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class LineageQuerier : ILineageQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<LineageEntity> _lineages;
  private readonly ISqlHelper _sqlHelper;

  public LineageQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _lineages = context.Lineages;
    _sqlHelper = sqlHelper;
  }

  public async Task<LineageModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    LineageEntity? lineage = await _lineages.AsNoTracking()
      .Include(x => x.Features).ThenInclude(x => x.Feature)
      .Include(x => x.Languages).ThenInclude(x => x.Language).ThenInclude(x => x!.Script)
      .Include(x => x.Parent)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return lineage is null ? null : await MapAsync(lineage, cancellationToken);
  }
  public async Task<LineageModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    LineageEntity? lineage = await _lineages.AsNoTracking()
      .Include(x => x.Features).ThenInclude(x => x.Feature)
      .Include(x => x.Languages).ThenInclude(x => x.Language).ThenInclude(x => x!.Script)
      .Include(x => x.Parent)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return lineage is null ? null : await MapAsync(lineage, cancellationToken);
  }

  public async Task<SearchResults<LineageModel>> SearchAsync(SearchLineagesPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Lineages.Table).SelectAll(RulesDb.Lineages.Table)
      .ApplyIdFilter(RulesDb.Lineages.Id, payload.Ids)
      .Where(RulesDb.Lineages.IsPublished, Operators.IsEqualTo(true))
      .Where(RulesDb.Lineages.ParentUid, payload.ParentId.HasValue ? Operators.IsEqualTo(payload.ParentId.Value) : Operators.IsNull());
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Lineages.Slug, RulesDb.Lineages.Name, RulesDb.Lineages.Summary);

    if (payload.LanguageId.HasValue)
    {
      OperatorCondition condition = new(RulesDb.LineageLanguages.LanguageUid, Operators.IsEqualTo(payload.LanguageId.Value));
      builder.Join(RulesDb.LineageLanguages.LineageId, RulesDb.Lineages.LineageId, condition);
    }
    if (payload.SizeCategory.HasValue)
    {
      builder.Where(RulesDb.Lineages.SizeCategory, Operators.IsEqualTo(payload.SizeCategory.Value));
    }

    IQueryable<LineageEntity> query = _lineages.FromQuery(builder).AsNoTracking();

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<LineageEntity>? ordered = null;
    foreach (LineageSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case LineageSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case LineageSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case LineageSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case LineageSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    LineageEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<LineageModel> lineages = await MapAsync(entities, cancellationToken);

    return new SearchResults<LineageModel>(lineages, total);
  }

  private async Task<LineageModel> MapAsync(LineageEntity lineage, CancellationToken cancellationToken)
  {
    return (await MapAsync([lineage], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<LineageModel>> MapAsync(IEnumerable<LineageEntity> lineages, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = lineages.SelectMany(lineage => lineage.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return lineages.Select(mapper.ToLineage).ToList().AsReadOnly();
  }
}
