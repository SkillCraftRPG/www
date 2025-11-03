using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Scripts;
using SkillCraft.Cms.Core.Scripts.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class ScriptQuerier : IScriptQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<ScriptEntity> _scripts;
  private readonly ISqlHelper _sqlHelper;

  public ScriptQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _scripts = context.Scripts;
    _sqlHelper = sqlHelper;
  }

  public async Task<ScriptModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    ScriptEntity? script = await _scripts.AsNoTracking()
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return script is null ? null : await MapAsync(script, cancellationToken);
  }
  public async Task<ScriptModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    ScriptEntity? script = await _scripts.AsNoTracking()
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return script is null ? null : await MapAsync(script, cancellationToken);
  }

  public async Task<SearchResults<ScriptModel>> SearchAsync(SearchScriptsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Scripts.Table).SelectAll(RulesDb.Scripts.Table)
      .ApplyIdFilter(RulesDb.Scripts.Id, payload.Ids)
      .Where(RulesDb.Scripts.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Scripts.Slug, RulesDb.Scripts.Name, RulesDb.Scripts.Summary);

    IQueryable<ScriptEntity> query = _scripts.FromQuery(builder).AsNoTracking();

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<ScriptEntity>? ordered = null;
    foreach (ScriptSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case ScriptSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case ScriptSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case ScriptSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case ScriptSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    ScriptEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<ScriptModel> scripts = await MapAsync(entities, cancellationToken);

    return new SearchResults<ScriptModel>(scripts, total);
  }

  private async Task<ScriptModel> MapAsync(ScriptEntity script, CancellationToken cancellationToken)
  {
    return (await MapAsync([script], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<ScriptModel>> MapAsync(IEnumerable<ScriptEntity> scripts, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = scripts.SelectMany(script => script.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return scripts.Select(mapper.ToScript).ToList().AsReadOnly();
  }
}
