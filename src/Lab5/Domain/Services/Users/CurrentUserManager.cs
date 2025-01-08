using Domain.Contracts.Users;
using Domain.Users.Common;

namespace Domain.Services.Users;

public class CurrentUserManager : ICurrentUserService
{
    public IUser? User { get; set; }
}
