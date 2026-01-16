using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Spells;
using SkillCraft.Cms.Core.Spells.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class SpellQuerier : ISpellQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<SpellEntity> _spells;
  private readonly ISqlHelper _sqlHelper;

  public SpellQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _spells = context.Spells;
    _sqlHelper = sqlHelper;
  }

  public async Task<SpellModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SpellEntity? spell = await _spells.AsNoTracking()
      .Include(x => x.Levels)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return spell is null ? null : await MapAsync(spell, cancellationToken);
  }
  public async Task<SpellModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    SpellEntity? spell = await _spells.AsNoTracking()
      .Include(x => x.Levels)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return spell is null ? null : await MapAsync(spell, cancellationToken);
  }

  public async Task<SearchResults<SpellModel>> SearchAsync(SearchSpellsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Spells.Table).SelectAll(RulesDb.Spells.Table)
      .ApplyIdFilter(RulesDb.Spells.Id, payload.Ids)
      .Where(RulesDb.Spells.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Spells.Slug, RulesDb.Spells.Name, RulesDb.Spells.Summary);

    if (payload.Slugs.Count > 0)
    {
      string[] normalizedSlugs = payload.Slugs.Where(slug => !string.IsNullOrWhiteSpace(slug))
        .Select(Helper.Normalize)
        .Distinct()
        .ToArray();
      builder.Where(RulesDb.Spells.SlugNormalized, Operators.IsIn(normalizedSlugs));
    }
    if (payload.Tiers.Count > 0)
    {
      object[] tiers = payload.Tiers.Distinct().Select(tier => (object)tier).ToArray();
      builder.Where(RulesDb.Spells.Tier, Operators.IsIn(tiers));
    }

    IQueryable<SpellEntity> query = _spells.FromQuery(builder).AsNoTracking()
      .Include(x => x.Levels);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<SpellEntity>? ordered = null;
    foreach (SpellSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case SpellSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case SpellSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case SpellSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case SpellSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    SpellEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<SpellModel> spells = await MapAsync(entities, cancellationToken);

    return new SearchResults<SpellModel>(spells, total);
  }

  private async Task<SpellModel> MapAsync(SpellEntity spell, CancellationToken cancellationToken)
  {
    return (await MapAsync([spell], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<SpellModel>> MapAsync(IEnumerable<SpellEntity> spells, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = spells.SelectMany(spell => spell.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return spells.Select(mapper.ToSpell).ToList().AsReadOnly();
  }
}
