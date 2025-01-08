using Domain.Users.Common;

namespace Domain.Contracts.Users;

public interface ICurrentUserService
{
    IUser? User { get; }
}
