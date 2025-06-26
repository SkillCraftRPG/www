using Krakenar.Contracts.Actors;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.Queriers.Rules;

internal class CustomizationQuerier : ICustomizationQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<CustomizationEntity> _customizations;

  public CustomizationQuerier(IActorService actorService, RuleContext rules)
  {
    _actorService = actorService;
    _customizations = rules.Customizations;
  }

  public async Task<IReadOnlyCollection<CustomizationModel>> ListAsync(CancellationToken cancellationToken)
  {
    CustomizationEntity[] customizations = await _customizations.AsNoTracking()
      .OrderBy(x => x.Name)
      .ToArrayAsync(cancellationToken);

    return await MapAsync(customizations, cancellationToken);
  }

  public async Task<CustomizationModel?> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    slug = slug.Trim().ToLowerInvariant();

    CustomizationEntity? customization = await _customizations.AsNoTracking()
      .SingleOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    return customization is null ? null : await MapAsync(customization, cancellationToken);
  }

  private async Task<CustomizationModel> MapAsync(CustomizationEntity entity, CancellationToken cancellationToken)
  {
    return (await MapAsync([entity], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<CustomizationModel>> MapAsync(IEnumerable<CustomizationEntity> customizations, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = customizations.SelectMany(customization => customization.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    RuleMapper mapper = new(actors);

    return customizations.Select(mapper.ToCustomization).ToList().AsReadOnly();
  }
}
