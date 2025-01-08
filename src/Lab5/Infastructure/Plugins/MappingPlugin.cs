using Domain.Currencies.Models;
using Domain.Users.Common;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Infastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>();
        builder.MapEnum<Currency>();
    }
}
