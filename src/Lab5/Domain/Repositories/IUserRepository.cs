using Domain.Users.Models;

namespace Domain.Repositories.Users;

public interface IUserRepository
{
    public User? FindUserByUsername(string username, string userpassword);
}
