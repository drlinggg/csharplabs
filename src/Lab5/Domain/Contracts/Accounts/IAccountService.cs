using Domain.Accounts.Common;
using Domain.Currencies.Models;

namespace Domain.Contracts.Accounts;

public interface IAccountService
{
    public IAccount? GetAccount(string username, string pin);

    public IAccount? CreateAccount(string username, Currency currency, string pin);

    public IAccount? UpdateAccount(long id, long amount, Currency currency);
}
