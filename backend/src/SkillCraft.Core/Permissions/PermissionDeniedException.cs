using Krakenar.Contracts;
using Logitar;

namespace SkillCraft.Core.Permissions;

public class PermissionDeniedException : ErrorException
{
  private const string ErrorMessage = "The specified permission was denied.";

  public Guid UserId
  {
    get => (Guid)Data[nameof(UserId)]!;
    private set => Data[nameof(UserId)] = value;
  }
  public string Action
  {
    get => (string)Data[nameof(Action)]!;
    private set => Data[nameof(Action)] = value;
  }
  public Resource? Resource
  {
    get => (Resource?)Data[nameof(Resource)];
    private set => Data[nameof(Resource)] = value;
  }

  public override Error Error => new(this.GetErrorCode(), ErrorMessage);

  public PermissionDeniedException(UserId userId, string action, Resource? resource) : base(BuildMessage(userId, action, resource))
  {
    UserId = userId.ToGuid();
    Action = action;
    Resource = resource;
  }

  private static string BuildMessage(UserId userId, string action, Resource? resource) => new ErrorMessageBuilder(ErrorMessage)
    .AddData(nameof(UserId), userId.ToGuid())
    .AddData(nameof(Action), action)
    .AddData(string.Join('.', nameof(Resource), nameof(Resource.Kind)), resource?.Kind, "<null>")
    .AddData(string.Join('.', nameof(Resource), nameof(Resource.Identifier)), resource?.Identifier, "<null>")
    .Build();
}
