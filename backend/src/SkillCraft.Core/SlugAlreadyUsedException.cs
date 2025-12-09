using Krakenar.Contracts;
using Logitar;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public class SlugAlreadyUsedException : ConflictException
{
  private const string ErrorMessage = "The specified slug is already in use.";

  public string Type
  {
    get => (string)Data[nameof(Type)]!;
    private set => Data[nameof(Type)] = value;
  }
  public string Slug
  {
    get => (string)Data[nameof(Slug)]!;
    private set => Data[nameof(Slug)] = value;
  }
  public Guid Id
  {
    get => (Guid)Data[nameof(Id)]!;
    private set => Data[nameof(Id)] = value;
  }
  public Guid ConflictId
  {
    get => (Guid)Data[nameof(ConflictId)]!;
    private set => Data[nameof(ConflictId)] = value;
  }

  public override Error Error
  {
    get
    {
      Error error = new(this.GetErrorCode(), ErrorMessage);
      error.Data[nameof(Type)] = Type;
      error.Data[nameof(Id)] = Id;
      error.Data[nameof(Slug)] = Slug;
      error.Data[nameof(ConflictId)] = ConflictId;
      return error;
    }
  }

  public SlugAlreadyUsedException(World world, WorldId conflictId) : base(BuildMessage(world, conflictId))
  {
    Type = world.GetType().Name;
    Id = world.Id.ToGuid();
    Slug = world.Slug.Value;
    ConflictId = conflictId.ToGuid();
  }

  private static string BuildMessage(World world, WorldId conflictId) => new ErrorMessageBuilder(ErrorMessage)
    .AddData(nameof(Type), world.GetType().Name)
    .AddData(nameof(Id), world.Id.ToGuid())
    .AddData(nameof(Slug), world.Slug)
    .AddData(nameof(ConflictId), conflictId.ToGuid())
    .Build();
}
