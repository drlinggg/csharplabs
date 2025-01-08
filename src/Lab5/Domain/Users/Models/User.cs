using Domain.Users.Common;

namespace Domain.Users.Models;

public class User : IUser
{
    public long Id { get; init; }

    public string Username { get; init; }

    public string HashedPassword { get; init; }

    public UserRole Role { get; private set; }

    public User(long id, string username, string hashedPassword, UserRole role)
    {
        Id = id;
        Username = username;
        HashedPassword = hashedPassword;
        Role = role;
    }
}
