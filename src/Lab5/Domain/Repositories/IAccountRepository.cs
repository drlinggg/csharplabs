using Domain.Accounts.Models;
using Domain.Currencies.Models;

namespace Domain.Repositories.Accounts;

public interface IAccountRepository
{
    public Account? FindAccountByUsernameAndPin(string username, string pin);

    public Account? CreateAccount(string username, Currency currency, string pin);

    public Account? UpdateAccount(long id, long amount, Currency currency);
}
