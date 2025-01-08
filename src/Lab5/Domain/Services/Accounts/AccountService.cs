using Domain.Accounts.Common;
using Domain.Contracts.Accounts;
using Domain.Currencies.Models;
using Domain.Repositories.Accounts;

namespace Domain.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public IAccount? GetAccount(string username, string pin)
    {
        return _repository.FindAccountByUsernameAndPin(username, pin);
    }

    public IAccount? CreateAccount(string username, Currency currency, string pin)
    {
        return _repository.CreateAccount(username, currency, pin);
    }

    public IAccount? UpdateAccount(long id, long amount, Currency currency)
    {
        return _repository.UpdateAccount(id, amount, currency);
    }
}
