using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Educations;
using SkillCraft.Cms.Core.Educations.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class EducationQuerier : IEducationQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<EducationEntity> _educations;
  private readonly ISqlHelper _sqlHelper;

  public EducationQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _educations = context.Educations;
    _sqlHelper = sqlHelper;
  }

  public async Task<EducationModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    EducationEntity? education = await _educations.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return education is null ? null : await MapAsync(education, cancellationToken);
  }
  public async Task<EducationModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    EducationEntity? education = await _educations.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return education is null ? null : await MapAsync(education, cancellationToken);
  }

  public async Task<SearchResults<EducationModel>> SearchAsync(SearchEducationsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Educations.Table).SelectAll(RulesDb.Educations.Table)
      .ApplyIdFilter(RulesDb.Educations.Id, payload.Ids)
      .Where(RulesDb.Educations.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Educations.Slug, RulesDb.Educations.Name, RulesDb.Educations.Summary);

    IQueryable<EducationEntity> query = _educations.FromQuery(builder).AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Feature);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<EducationEntity>? ordered = null;
    foreach (EducationSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case EducationSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case EducationSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case EducationSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case EducationSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    EducationEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<EducationModel> educations = await MapAsync(entities, cancellationToken);

    return new SearchResults<EducationModel>(educations, total);
  }

  private async Task<EducationModel> MapAsync(EducationEntity education, CancellationToken cancellationToken)
  {
    return (await MapAsync([education], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<EducationModel>> MapAsync(IEnumerable<EducationEntity> educations, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = educations.SelectMany(education => education.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return educations.Select(mapper.ToEducation).ToList().AsReadOnly();
  }
}
