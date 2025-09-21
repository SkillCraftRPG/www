using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Statistics;
using SkillCraft.Cms.Core.Statistics.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class StatisticQuerier : IStatisticQuerier
{
  private readonly IActorService _actorService;
  private readonly ISqlHelper _sqlHelper;
  private readonly DbSet<StatisticEntity> _statistics;

  public StatisticQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _sqlHelper = sqlHelper;
    _statistics = context.Statistics;
  }

  public async Task<StatisticModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    StatisticEntity? statistic = await _statistics.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return statistic is null ? null : await MapAsync(statistic, cancellationToken);
  }
  public async Task<StatisticModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    StatisticEntity? statistic = await _statistics.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return statistic is null ? null : await MapAsync(statistic, cancellationToken);
  }

  public async Task<SearchResults<StatisticModel>> SearchAsync(SearchStatisticsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Statistics.Table).SelectAll(RulesDb.Statistics.Table)
      .ApplyIdFilter(RulesDb.Statistics.Id, payload.Ids)
      .Where(RulesDb.Statistics.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Statistics.Slug, RulesDb.Statistics.Name, RulesDb.Statistics.Summary);

    IQueryable<StatisticEntity> query = _statistics.FromQuery(builder).AsNoTracking()
      .Include(x => x.Attribute);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<StatisticEntity>? ordered = null;
    foreach (StatisticSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case StatisticSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case StatisticSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case StatisticSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case StatisticSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    StatisticEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<StatisticModel> statistics = await MapAsync(entities, cancellationToken);

    return new SearchResults<StatisticModel>(statistics, total);
  }

  private async Task<StatisticModel> MapAsync(StatisticEntity statistic, CancellationToken cancellationToken)
  {
    return (await MapAsync([statistic], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<StatisticModel>> MapAsync(IEnumerable<StatisticEntity> statistics, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = statistics.SelectMany(statistic => statistic.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return statistics.Select(mapper.ToStatistic).ToList().AsReadOnly();
  }
}
