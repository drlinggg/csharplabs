using Domain.Accounts.Common;
using Domain.Contracts.Accounts;

namespace Domain.Services.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public IAccount? Account { get; set; }
}
