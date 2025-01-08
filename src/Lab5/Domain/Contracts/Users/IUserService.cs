using Domain.Contracts.Users.ResultTypes;

namespace Domain.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);

    LoginResult LoginAsRoot(string username, string password);
}
