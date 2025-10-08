using Krakenar.Contracts.Users;
using Krakenar.Core;
using Krakenar.Core.Users;
using Logitar.EventSourcing;
using SkillCraft.Cms.Seeding.Krakenar.Models;
using User = Krakenar.Contracts.Users.User;

namespace SkillCraft.Cms.Seeding.Krakenar.Tasks;

internal class SeedUsersTask : SeedingTask
{
  public override string? Description => "Seeds the Users into Krakenar.";
}

internal class SeedUsersTaskHandler : ICommandHandler<SeedUsersTask, TaskResult>
{
  private readonly IApplicationContext _applicationContext;
  private readonly IUserService _userService;
  private readonly ILogger<SeedUsersTaskHandler> _logger;

  public SeedUsersTaskHandler(IApplicationContext applicationContext, ILogger<SeedUsersTaskHandler> logger, IUserService userService)
  {
    _applicationContext = applicationContext;
    _logger = logger;
    _userService = userService;
  }

  public async Task<TaskResult> HandleAsync(SeedUsersTask _, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Krakenar/data/users.json", Encoding.UTF8, cancellationToken);
    IEnumerable<UserPayload>? payloads = SeedingSerializer.Deserialize<IEnumerable<UserPayload>>(json);
    if (payloads is not null)
    {
      foreach (UserPayload payload in payloads)
      {
        if (!payload.Id.HasValue)
        {
          ActorId? actorId = _applicationContext.ActorId;
          if (!actorId.HasValue)
          {
            throw new InvalidOperationException("An user actor is required.");
          }
          UserId userId = new(actorId.Value.Value);
          payload.Id = userId.EntityId;
        }

        CreateOrReplaceUserResult result = await _userService.CreateOrReplaceAsync(payload, payload.Id, version: null, cancellationToken);
        User user = result.User ?? throw new InvalidOperationException($"'UserService.CreateOrReplaceAsync' returned null for user 'Id={payload.Id}'.");
        _logger.LogInformation("The user '{User}' was {Action}.", user.FullName ?? user.UniqueName, result.Created ? "created" : "replaced");
      }
    }

    return new TaskResult();
  }
}
