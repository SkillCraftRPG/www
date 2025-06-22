using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class StatisticQuerier : IStatisticQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<StatisticEntity> _statistics;

  public StatisticQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _statistics = rules.Statistics;
  }

  public async Task<IReadOnlyCollection<StatisticModel>> ListAsync(CancellationToken cancellationToken)
  {
    StatisticEntity[] statistics = await _statistics.AsNoTracking()
      .Include(x => x.Attribute)
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(statistics, cancellationToken);
  }

  public async Task<StatisticModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    StatisticEntity? statistic = await _statistics.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return statistic is null ? null : await MapAsync(statistic, cancellationToken);
  }

  private async Task<StatisticModel> MapAsync(StatisticEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<StatisticModel>> MapAsync(IEnumerable<StatisticEntity> statistics, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = statistics.SelectMany(statistic => statistic.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return statistics.Select(mapper.ToStatistic).ToList().AsReadOnly();
  }
}
