using Domain.Contracts.Users;
using Domain.Contracts.Users.ResultTypes;
using Domain.Repositories.Users;
using Domain.Users.Common;
using Domain.Users.Models;

namespace Domain.Services.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;

    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username, string password)
    {
        IUser? user = _repository.FindUserByUsername(username, password);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public LoginResult LoginAsRoot(string username, string password)
    {
        User? user = _repository.FindUserByUsername(username, password);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        _currentUserManager.User = user;

        if (user.Role != UserRole.Admin)
            return new LoginResult.Failure();

        return new LoginResult.Success();
    }
}
