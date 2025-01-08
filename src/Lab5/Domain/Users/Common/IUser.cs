namespace Domain.Users.Common;

public interface IUser
{
    public long Id { get; init; }

    public string Username { get; init; }

    public string HashedPassword { get; init; }

    public UserRole Role { get; }
}
