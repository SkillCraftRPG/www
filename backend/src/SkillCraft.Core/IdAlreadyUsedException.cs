using Krakenar.Contracts;
using Logitar;

namespace SkillCraft.Core;

public class IdAlreadyUsedException : ConflictException
{
  private const string ErrorMessage = "The specified identifier is already in use.";

  public string Type
  {
    get => (string)Data[nameof(Type)]!;
    private set => Data[nameof(Type)] = value;
  }
  public Guid Id
  {
    get => (Guid)Data[nameof(Id)]!;
    private set => Data[nameof(Id)] = value;
  }

  public override Error Error
  {
    get
    {
      Error error = new(this.GetErrorCode(), ErrorMessage);
      error.Data[nameof(Type)] = Type;
      error.Data[nameof(Id)] = Id;
      return error;
    }
  }

  public IdAlreadyUsedException(Type type, Guid id) : base(BuildMessage(type, id))
  {
    Type = type.Name;
    Id = id;
  }

  private static string BuildMessage(Type type, Guid id) => new ErrorMessageBuilder(ErrorMessage)
    .AddData(nameof(Type), type.Name)
    .AddData(nameof(Id), id)
    .Build();
}

public class IdAlreadyUsedException<T> : IdAlreadyUsedException
{
  public IdAlreadyUsedException(Guid id) : base(typeof(T), id)
  {
  }
}
