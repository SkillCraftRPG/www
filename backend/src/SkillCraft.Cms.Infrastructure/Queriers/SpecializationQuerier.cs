using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Specializations;
using SkillCraft.Cms.Core.Specializations.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class SpecializationQuerier : ISpecializationQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<SpecializationDiscountedTalentEntity> _discountedTalents;
  private readonly DbSet<SpecializationOptionalTalentEntity> _optionalTalents;
  private readonly ISqlHelper _sqlHelper;
  private readonly DbSet<SpecializationEntity> _specializations;

  public SpecializationQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _discountedTalents = context.SpecializationDiscountedTalents;
    _optionalTalents = context.SpecializationOptionalTalents;
    _sqlHelper = sqlHelper;
    _specializations = context.Specializations;
  }

  public async Task<SpecializationModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SpecializationEntity? specialization = await _specializations.AsNoTracking()
      .Include(x => x.Features).ThenInclude(x => x.Feature)
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.RequiredTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);

    if (specialization is null)
    {
      return null;
    }
    await FillAsync(specialization, cancellationToken);
    return await MapAsync(specialization, cancellationToken);
  }
  public async Task<SpecializationModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    SpecializationEntity? specialization = await _specializations.AsNoTracking()
      .Include(x => x.Features).ThenInclude(x => x.Feature)
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.RequiredTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);

    if (specialization is null)
    {
      return null;
    }
    await FillAsync(specialization, cancellationToken);
    return await MapAsync(specialization, cancellationToken);
  }
  private async Task FillAsync(SpecializationEntity specialization, CancellationToken cancellationToken)
  {
    SpecializationDiscountedTalentEntity[] discountedTalents = await _discountedTalents.AsNoTracking()
      .Include(x => x.Talent).ThenInclude(x => x!.RequiredTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Talent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Where(x => x.SpecializationId == specialization.SpecializationId)
      .ToArrayAsync(cancellationToken);
    specialization.DiscountedTalents.AddRange(discountedTalents);

    SpecializationOptionalTalentEntity[] optionalTalents = await _optionalTalents.AsNoTracking()
      .Include(x => x.Talent).ThenInclude(x => x!.RequiredTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.Talent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Where(x => x.SpecializationId == specialization.SpecializationId)
      .ToArrayAsync(cancellationToken);
    specialization.OptionalTalents.AddRange(optionalTalents);
  }

  public async Task<SearchResults<SpecializationModel>> SearchAsync(SearchSpecializationsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Specializations.Table).SelectAll(RulesDb.Specializations.Table)
      .ApplyIdFilter(RulesDb.Specializations.Id, payload.Ids)
      .Where(RulesDb.Specializations.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Specializations.Slug, RulesDb.Specializations.Name, RulesDb.Specializations.Summary);

    IQueryable<SpecializationEntity> query = _specializations.FromQuery(builder).AsNoTracking()
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.RequiredTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.MandatoryTalent).ThenInclude(x => x!.Skill).ThenInclude(x => x!.Attribute);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<SpecializationEntity>? ordered = null;
    foreach (SpecializationSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case SpecializationSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case SpecializationSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case SpecializationSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case SpecializationSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    SpecializationEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<SpecializationModel> specializations = await MapAsync(entities, cancellationToken);

    return new SearchResults<SpecializationModel>(specializations, total);
  }

  private async Task<SpecializationModel> MapAsync(SpecializationEntity specialization, CancellationToken cancellationToken)
  {
    return (await MapAsync([specialization], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<SpecializationModel>> MapAsync(IEnumerable<SpecializationEntity> specializations, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = specializations.SelectMany(specialization => specialization.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return specializations.Select(mapper.ToSpecialization).ToList().AsReadOnly();
  }
}
