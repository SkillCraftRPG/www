using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class AttributeQuerier : IAttributeQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<AttributeEntity> _attributes;

  public AttributeQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _attributes = rules.Attributes;
  }

  public async Task<IReadOnlyCollection<AttributeModel>> ListAsync(CancellationToken cancellationToken)
  {
    AttributeEntity[] attributes = await _attributes.AsNoTracking()
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(attributes, cancellationToken);
  }

  public async Task<AttributeModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    AttributeEntity? attribute = await _attributes.AsNoTracking().SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return attribute is null ? null : await MapAsync(attribute, cancellationToken);
  }

  private async Task<AttributeModel> MapAsync(AttributeEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<AttributeModel>> MapAsync(IEnumerable<AttributeEntity> attributes, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = attributes.SelectMany(attribute => attribute.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return attributes.Select(mapper.ToAttribute).ToList().AsReadOnly();
  }
}
