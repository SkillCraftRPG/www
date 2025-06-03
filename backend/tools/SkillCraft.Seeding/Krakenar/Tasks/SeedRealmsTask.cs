using Krakenar.Contracts.Realms;
using MediatR;
using SkillCraft.Seeding.Krakenar.Payloads;

namespace SkillCraft.Seeding.Krakenar.Tasks;

internal class SeedRealmsTask : SeedingTask
{
  public override string? Description => "Seeds the Realms into Krakenar.";
}

internal class SeedRealmsTaskHandler : INotificationHandler<SeedRealmsTask>
{
  private readonly ILogger<SeedRealmsTaskHandler> _logger;
  private readonly IRealmService _realmService;

  public SeedRealmsTaskHandler(ILogger<SeedRealmsTaskHandler> logger, IRealmService realmService)
  {
    _logger = logger;
    _realmService = realmService;
  }

  public async Task Handle(SeedRealmsTask _, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Krakenar/data/realms.json", Encoding.UTF8, cancellationToken);
    IEnumerable<RealmPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<RealmPayload>>(json);
    if (payloads is not null)
    {
      foreach (RealmPayload payload in payloads)
      {
        CreateOrReplaceRealmResult result = await _realmService.CreateOrReplaceAsync(payload, payload.Id, version: null, cancellationToken);
        if (result.Realm is null)
        {
          throw new InvalidOperationException($"'RealmService.CreateOrReplaceAsync' returned null for realm 'Id={payload.Id}'.");
        }
        else if (result.Created)
        {
          _logger.LogInformation("The realm '{Realm}' was replaced.", result.Realm.DisplayName ?? result.Realm.UniqueSlug);
        }
        else
        {
          _logger.LogInformation("The realm '{Realm}' was replaced.", result.Realm.DisplayName ?? result.Realm.UniqueSlug);
        }
      }
    }
  }
}
