using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Krakenar.EntityFrameworkCore.Relational;
using Krakenar.EntityFrameworkCore.Relational.KrakenarDb;
using Logitar.Data;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Cms.Core.Customizations;
using SkillCraft.Cms.Core.Customizations.Models;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.Queriers;

internal class CustomizationQuerier : ICustomizationQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<CustomizationEntity> _customizations;
  private readonly ISqlHelper _sqlHelper;

  public CustomizationQuerier(IActorService actorService, RulesContext context, ISqlHelper sqlHelper)
  {
    _actorService = actorService;
    _customizations = context.Customizations;
    _sqlHelper = sqlHelper;
  }

  public async Task<CustomizationModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    CustomizationEntity? customization = await _customizations.AsNoTracking()
      .SingleOrDefaultAsync(x => x.Id == id && x.IsPublished, cancellationToken);
    return customization is null ? null : await MapAsync(customization, cancellationToken);
  }
  public async Task<CustomizationModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    string slugNormalized = Helper.Normalize(slug);

    CustomizationEntity? customization = await _customizations.AsNoTracking()
      .SingleOrDefaultAsync(x => x.SlugNormalized == slugNormalized && x.IsPublished, cancellationToken);
    return customization is null ? null : await MapAsync(customization, cancellationToken);
  }

  public async Task<SearchResults<CustomizationModel>> SearchAsync(SearchCustomizationsPayload payload, CancellationToken cancellationToken)
  {
    IQueryBuilder builder = _sqlHelper.Query(RulesDb.Customizations.Table).SelectAll(RulesDb.Customizations.Table)
      .ApplyIdFilter(RulesDb.Customizations.Id, payload.Ids)
      .Where(RulesDb.Customizations.IsPublished, Operators.IsEqualTo(true));
    _sqlHelper.ApplyTextSearch(builder, payload.Search, RulesDb.Customizations.Slug, RulesDb.Customizations.Name, RulesDb.Customizations.Summary);

    if (payload.Kind.HasValue)
    {
      builder.Where(RulesDb.Customizations.Kind, Operators.IsEqualTo(payload.Kind.Value.ToString()));
    }

    IQueryable<CustomizationEntity> query = _customizations.FromQuery(builder).AsNoTracking();

    long total = await query.LongCountAsync(cancellationToken);

    IOrderedQueryable<CustomizationEntity>? ordered = null;
    foreach (CustomizationSortOption sort in payload.Sort)
    {
      switch (sort.Field)
      {
        case CustomizationSort.CreatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.CreatedOn) : ordered.ThenBy(x => x.CreatedOn));
          break;
        case CustomizationSort.Name:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Name ?? x.Slug) : query.OrderBy(x => x.Name ?? x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Name ?? x.Slug) : ordered.ThenBy(x => x.Name ?? x.Slug));
          break;
        case CustomizationSort.Slug:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.Slug) : query.OrderBy(x => x.Slug))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.Slug) : ordered.ThenBy(x => x.Slug));
          break;
        case CustomizationSort.UpdatedOn:
          ordered = (ordered is null)
            ? (sort.IsDescending ? query.OrderByDescending(x => x.UpdatedOn) : query.OrderBy(x => x.UpdatedOn))
            : (sort.IsDescending ? ordered.ThenByDescending(x => x.UpdatedOn) : ordered.ThenBy(x => x.UpdatedOn));
          break;
      }
    }
    query = ordered ?? query;

    query = query.ApplyPaging(payload);

    CustomizationEntity[] entities = await query.ToArrayAsync(cancellationToken);
    IReadOnlyCollection<CustomizationModel> customizations = await MapAsync(entities, cancellationToken);

    return new SearchResults<CustomizationModel>(customizations, total);
  }

  private async Task<CustomizationModel> MapAsync(CustomizationEntity customization, CancellationToken cancellationToken)
  {
    return (await MapAsync([customization], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<CustomizationModel>> MapAsync(IEnumerable<CustomizationEntity> customizations, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = customizations.SelectMany(customization => customization.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RulesMapper mapper = new(actors);

    return customizations.Select(mapper.ToCustomization).ToList().AsReadOnly();
  }
}
