using Domain.Repositories.Users;
using Domain.Users.Common;
using Domain.Users.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infastructure.DataAccess.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username, string userpassword)
    {
        const string sql = """
        select users.user_id, users.user_name, users.user_role, user_passwords.user_password
        from users
        join user_passwords on users.user_id = user_passwords.user_id
        WHERE users.user_name = :username AND user_passwords.user_password = :userpassword;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("username", username)
            .AddParameter("userpassword", userpassword);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            reader.GetInt64(0),
            reader.GetString(1),
            reader.GetString(3),
            reader.GetFieldValue<UserRole>(2));
    }
}
