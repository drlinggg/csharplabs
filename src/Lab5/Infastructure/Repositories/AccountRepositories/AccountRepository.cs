using Domain.Accounts.Models;
using Domain.Currencies.Models;
using Domain.Repositories.Accounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infastructure.DataAccess.Repositories.Accounts;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountByUsernameAndPin(string username, string pin)
    {
        const string sql = """
        select accounts.account_id, accounts.currency, accounts.amount
        from accounts
        join users
        on accounts.user_id = users.user_id
        join account_pins
        on accounts.account_id = account_pins.account_id
        where user_name = :username and
        account_pins.account_pin = :pin;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("username", username)
            .AddParameter("pin", pin);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        long accountId = reader.GetInt64(0);
        string currencyString = reader.GetString(1);
        if (Enum.TryParse<Currency>(currencyString, out Currency currency))
        {
           long amount = reader.GetInt64(2);
           return new Account(
                   accountId,
                   currency,
                   amount);
        }

        return null;
    }

    public Account? CreateAccount(string username, Currency currency, string pin)
    {
        const string sql = """
        insert into accounts (currency, amount, user_id) 
        values (currency,
                0,
                (select user_id from users where user_name = :username);
        insert into account_pins (account_pin)
        values (:pin);
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("username", username)
            .AddParameter("pin", pin)
            .AddParameter("currency", currency);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return FindAccountByUsernameAndPin(username, pin);
    }

    public Account? UpdateAccount(long id, long amount, Currency currency)
    {
        const string sql = """
        update accounts
        set amount = :amount
        where account_id = :id;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id)
            .AddParameter("amount", amount);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return null;
    }
}
