using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class EducationQuerier : IEducationQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<EducationEntity> _educations;

  public EducationQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _educations = rules.Educations;
  }

  public async Task<IReadOnlyCollection<EducationModel>> ListAsync(CancellationToken cancellationToken)
  {
    EducationEntity[] educations = await _educations.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(educations, cancellationToken);
  }

  public async Task<EducationModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    EducationEntity? education = await _educations.AsNoTracking()
      .Include(x => x.Skill).ThenInclude(x => x!.Attribute)
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return education is null ? null : await MapAsync(education, cancellationToken);
  }

  private async Task<EducationModel> MapAsync(EducationEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<EducationModel>> MapAsync(IEnumerable<EducationEntity> educations, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = educations.SelectMany(education => education.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return educations.Select(mapper.ToEducation).ToList().AsReadOnly();
  }
}
