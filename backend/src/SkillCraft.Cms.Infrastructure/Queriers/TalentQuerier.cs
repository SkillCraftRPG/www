using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Talents;
using SkillCraft.Cms.Core.Talents.Models;
using SkillCraft.Cms.Infrastructure.Entities;
using KrakenarDb = Krakenar.EntityFrameworkCore.Relational.KrakenarDb;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class TalentQuerier : ITalentQuerier
{
  private readonly IActorService _actorService;
  private readonly ISqlHelper _sqlHelper;
  private readonly DbSet<TalentEntity> _talents;

  public TalentQuerier(IActorService actorService, CmsContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _sqlHelper = sqlHelper;
    _talents = context.Talents;
  }

  public async Task<Talent?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    TalentEntity? talent = await _talents.AsNoTracking()
      .Include(x => x.RequiredTalent)
      .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    // TODO(fpion): IsPublished and RequiredTalent.IsPublished
    return talent is null ? null : await MapAsync(talent, cancellationToken);
  }
  public async Task<Talent?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = KrakenarDb.Helper.Normalize(slug);

    TalentEntity? talent = await _talents.AsNoTracking()
      .Include(x => x.RequiredTalent)
      .SingleOrDefaultAsync(x => x.Slug == slugNormalized, cancellationToken); // TODO(fpion): slug normalized
    // TODO(fpion): IsPublished and RequiredTalent.IsPublished
    return talent is null ? null : await MapAsync(talent, cancellationToken);
  }

  public async Task<SearchResults<Talent>> SearchAsync(SearchTalentsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(CmsDb.Talents.Table).SelectAll(CmsDb.Talents.Table)
      .ApplyIdFilter(CmsDb.Talents.Id, payload.Ids);
    // TODO(fpion): IsPublished and RequiredTalent.IsPublished
    _sqlHelper.ApplyTextSearch(builder, payload.Search, CmsDb.Talents.Slug, CmsDb.Talents.Name, CmsDb.Talents.Summary);

    if (payload.Slugs.Count > 0)
    {
      string[] slugs = payload.Slugs.Where(slug => !string.IsNullOrWhiteSpace(slug))
        .Select(slug => slug.Trim())
        .Distinct()
        .ToArray();
      builder.Where(CmsDb.Talents.Slug, Operators.IsIn(slugs)); // TODO(fpion): case-sensitive?
    }
    if (payload.Tiers.Count > 0)
    {
      object[] tiers = payload.Tiers.Distinct().Select(tier => (object)tier).ToArray();
      builder.Where(CmsDb.Talents.Tier, Operators.IsIn(tiers));
    }
    // TODO(fpion): HasSkill, HasNoSkill, HasExactSkill, Skills?
    if (payload.AllowMultiplePurchases.HasValue)
    {
      builder.Where(CmsDb.Talents.AllowMultiplePurchases, Operators.IsEqualTo(payload.AllowMultiplePurchases.Value));
    }
    if (payload.RequiredTalentId.HasValue)
    {
      builder.Where(CmsDb.Talents.RequiredTalentUid, Operators.IsEqualTo(payload.RequiredTalentId.Value)); // TODO(fpion): test with PostgreSQL
    }

    IQueryable<TalentEntity> query = _talents.FromQuery(builder).AsNoTracking();

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<TalentEntity>? ordered = null;
    foreach (TalentSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case TalentSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case TalentSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case TalentSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case TalentSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    TalentEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<Talent> talents = await MapAsync(entities, cancellationToken);

    return new SearchResults<Talent>(talents, total);
  }

  private async Task<Talent> MapAsync(TalentEntity talent, CancellationToken cancellationToken)
  {
    return (await MapAsync([talent], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<Talent>> MapAsync(IEnumerable<TalentEntity> talents, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = talents.SelectMany(talent => talent.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    CmsMapper mapper = new(actors);

    return talents.Select(mapper.ToTalent).ToList().AsReadOnly();
  }
}
