using Domain.Accounts.Common;

namespace Domain.Contracts.Accounts;

public interface ICurrentAccountService
{
    IAccount? Account { get; }
}
