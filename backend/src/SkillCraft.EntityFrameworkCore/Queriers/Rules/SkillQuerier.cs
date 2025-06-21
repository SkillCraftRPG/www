using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class SkillQuerier : ISkillQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<SkillEntity> _skills;

  public SkillQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _skills = rules.Skills;
  }

  public async Task<IReadOnlyCollection<SkillModel>> ListAsync(CancellationToken cancellationToken)
  {
    SkillEntity[] skills = await _skills.AsNoTracking()
      .Include(x => x.Attribute)
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(skills, cancellationToken);
  }

  public async Task<SkillModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    SkillEntity? skill = await _skills.AsNoTracking()
      .Include(x => x.Attribute)
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return skill is null ? null : await MapAsync(skill, cancellationToken);
  }

  private async Task<SkillModel> MapAsync(SkillEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<SkillModel>> MapAsync(IEnumerable<SkillEntity> skills, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = skills.SelectMany(skill => skill.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return skills.Select(mapper.ToSkill).ToList().AsReadOnly();
  }
}
