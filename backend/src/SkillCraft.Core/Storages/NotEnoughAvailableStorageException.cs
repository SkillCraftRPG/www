using Krakenar.Contracts;
using Logitar;

namespace SkillCraft.Core.Storages;

public class NotEnoughAvailableStorageException : ErrorException
{
  private const string ErrorMessage = "There is not enough available storage.";

  public Guid UserId
  {
    get => (Guid)Data[nameof(UserId)]!;
    private set => Data[nameof(UserId)] = value;
  }
  public long AvailableBytes
  {
    get => (long)Data[nameof(AvailableBytes)]!;
    private set => Data[nameof(AvailableBytes)] = value;
  }
  public long RequiredBytes
  {
    get => (long)Data[nameof(RequiredBytes)]!;
    private set => Data[nameof(RequiredBytes)] = value;
  }

  public override Error Error
  {
    get
    {
      Error error = new(this.GetErrorCode(), ErrorMessage);
      error.Data[nameof(UserId)] = UserId;
      error.Data[nameof(AvailableBytes)] = AvailableBytes;
      error.Data[nameof(RequiredBytes)] = RequiredBytes;
      return error;
    }
  }

  public NotEnoughAvailableStorageException(Storage storage, long requiredBytes) : base(BuildMessage(storage, requiredBytes))
  {
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(requiredBytes, nameof(requiredBytes));
    UserId = storage.UserId.ToGuid();
    AvailableBytes = storage.AvailableBytes;
    RequiredBytes = requiredBytes;
  }

  private static string BuildMessage(Storage storage, long requiredBytes) => new ErrorMessageBuilder(ErrorMessage)
    .AddData(nameof(UserId), storage.UserId.ToGuid())
    .AddData(nameof(AvailableBytes), storage.AvailableBytes)
    .AddData(nameof(RequiredBytes), requiredBytes)
    .Build();
}
