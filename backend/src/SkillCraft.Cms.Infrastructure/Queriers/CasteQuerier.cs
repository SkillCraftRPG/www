using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Castes;
using SkillCraft.Cms.Core.Castes.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class CasteQuerier : ICasteQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<CasteEntity> _castes;
  private readonly ISqlHelper _sqlHelper;

  public CasteQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _castes = context.Castes;
    _sqlHelper = sqlHelper;
  }

  public async Task<CasteModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    CasteEntity? caste = await _castes.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return caste is null ? null : await MapAsync(caste, cancellationToken);
  }
  public async Task<CasteModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    CasteEntity? caste = await _castes.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return caste is null ? null : await MapAsync(caste, cancellationToken);
  }

  public async Task<SearchResults<CasteModel>> SearchAsync(SearchCastesPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Castes.Table).SelectAll(RulesDb.Castes.Table)
      .ApplyIdFilter(RulesDb.Castes.Id, payload.Ids)
      .Where(RulesDb.Castes.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Castes.Slug, RulesDb.Castes.Name, RulesDb.Castes.Summary);

    IQueryable<CasteEntity> query = _castes.FromQuery(builder).AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<CasteEntity>? ordered = null;
    foreach (CasteSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case CasteSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case CasteSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case CasteSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case CasteSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    CasteEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<CasteModel> castes = await MapAsync(entities, cancellationToken);

    return new SearchResults<CasteModel>(castes, total);
  }

  private async Task<CasteModel> MapAsync(CasteEntity caste, CancellationToken cancellationToken)
  {
    return (await MapAsync([caste], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<CasteModel>> MapAsync(IEnumerable<CasteEntity> castes, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = castes.SelectMany(caste => caste.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return castes.Select(mapper.ToCaste).ToList().AsReadOnly();
  }
}
