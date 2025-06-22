using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class TalentQuerier : ITalentQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<TalentEntity> _talents;

  public TalentQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _talents = rules.Talents;
  }

  public async Task<IReadOnlyCollection<TalentModel>> ListAsync(CancellationToken cancellationToken)
  {
    TalentEntity[] talents = await _talents.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.RequiredTalent)
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(talents, cancellationToken);
  }

  public async Task<TalentModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    TalentEntity? talent = await _talents.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .Include(x => x.RequiredTalent)
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return talent is null ? null : await MapAsync(talent, cancellationToken);
  }

  private async Task<TalentModel> MapAsync(TalentEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<TalentModel>> MapAsync(IEnumerable<TalentEntity> talents, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = talents.SelectMany(talent => talent.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return talents.Select(mapper.ToTalent).ToList().AsReadOnly();
  }
}
