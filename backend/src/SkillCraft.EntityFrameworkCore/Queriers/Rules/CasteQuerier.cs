using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class CasteQuerier : ICasteQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<CasteEntity> _castes;

  public CasteQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _castes = rules.Castes;
  }

  public async Task<IReadOnlyCollection<CasteModel>> ListAsync(CancellationToken cancellationToken)
  {
    CasteEntity[] castes = await _castes.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(castes, cancellationToken);
  }

  public async Task<CasteModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    CasteEntity? caste = await _castes.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return caste is null ? null : await MapAsync(caste, cancellationToken);
  }

  private async Task<CasteModel> MapAsync(CasteEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<CasteModel>> MapAsync(IEnumerable<CasteEntity> castes, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = castes.SelectMany(caste => caste.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return castes.Select(mapper.ToCaste).ToList().AsReadOnly();
  }
}
