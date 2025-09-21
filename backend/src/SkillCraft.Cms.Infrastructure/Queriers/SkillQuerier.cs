using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Skills;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class SkillQuerier : ISkillQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<SkillEntity> _skills;
  private readonly ISqlHelper _sqlHelper;

  public SkillQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _skills = context.Skills;
    _sqlHelper = sqlHelper;
  }

  public async Task<SkillModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SkillEntity? skill = await _skills.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return skill is null ? null : await MapAsync(skill, cancellationToken);
  }
  public async Task<SkillModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    SkillEntity? skill = await _skills.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return skill is null ? null : await MapAsync(skill, cancellationToken);
  }

  public async Task<SearchResults<SkillModel>> SearchAsync(SearchSkillsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Skills.Table).SelectAll(RulesDb.Skills.Table)
      .ApplyIdFilter(RulesDb.Skills.Id, payload.Ids)
      .Where(RulesDb.Skills.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Skills.Slug, RulesDb.Skills.Name, RulesDb.Skills.Summary);

    IQueryable<SkillEntity> query = _skills.FromQuery(builder).AsNoTracking()
      .Include(x => x.Attribute);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<SkillEntity>? ordered = null;
    foreach (SkillSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case SkillSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case SkillSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case SkillSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case SkillSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    SkillEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<SkillModel> skills = await MapAsync(entities, cancellationToken);

    return new SearchResults<SkillModel>(skills, total);
  }

  private async Task<SkillModel> MapAsync(SkillEntity skill, CancellationToken cancellationToken)
  {
    return (await MapAsync([skill], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<SkillModel>> MapAsync(IEnumerable<SkillEntity> skills, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = skills.SelectMany(skill => skill.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return skills.Select(mapper.ToSkill).ToList().AsReadOnly();
  }
}
