using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class AttributeQuerier : IAttributeQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<AttributeEntity> _attributes;
  private readonly ISqlHelper _sqlHelper;

  public AttributeQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _attributes = context.Attributes;
    _sqlHelper = sqlHelper;
  }

  public async Task<AttributeModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    AttributeEntity? attribute = await _attributes.AsNoTracking()
      .Include(x => x.Statistics)
      .Include(x => x.Skills)
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return attribute is null ? null : await MapAsync(attribute, cancellationToken);
  }
  public async Task<AttributeModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    AttributeEntity? attribute = await _attributes.AsNoTracking()
      .Include(x => x.Statistics)
      .Include(x => x.Skills)
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return attribute is null ? null : await MapAsync(attribute, cancellationToken);
  }

  public async Task<SearchResults<AttributeModel>> SearchAsync(SearchAttributesPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Attributes.Table).SelectAll(RulesDb.Attributes.Table)
      .ApplyIdFilter(RulesDb.Attributes.Id, payload.Ids)
      .Where(RulesDb.Attributes.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Attributes.Slug, RulesDb.Attributes.Name, RulesDb.Attributes.Summary);

    IQueryable<AttributeEntity> query = _attributes.FromQuery(builder).AsNoTracking()
      .Include(x => x.Statistics)
      .Include(x => x.Skills);

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<AttributeEntity>? ordered = null;
    foreach (AttributeSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case AttributeSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case AttributeSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case AttributeSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case AttributeSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    AttributeEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<AttributeModel> attributes = await MapAsync(entities, cancellationToken);

    return new SearchResults<AttributeModel>(attributes, total);
  }

  private async Task<AttributeModel> MapAsync(AttributeEntity attribute, CancellationToken cancellationToken)
  {
    return (await MapAsync([attribute], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<AttributeModel>> MapAsync(IEnumerable<AttributeEntity> attributes, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = attributes.SelectMany(attribute => attribute.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return attributes.Select(mapper.ToAttribute).ToList().AsReadOnly();
  }
}
