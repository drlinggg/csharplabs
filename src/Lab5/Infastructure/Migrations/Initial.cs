using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'admin',
        'client'
    );

    create type currency as enum
    (
        'Ruble',
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_role user_role not null 
    );

    create table user_passwords
    (
        user_id BIGINT REFERENCES users(user_id) ON DELETE CASCADE, -- Added ON DELETE CASCADE
        user_password varchar(30)

    );

    create table accounts
    (
        account_id bigint primary key generated always as identity ,
        currency currency not null,
        amount bigint not null,
        user_id bigint references users(user_id)
    );

    CREATE TABLE account_pins (
        account_id BIGINT REFERENCES accounts(account_id) ON DELETE CASCADE, -- Added ON DELETE CASCADE
        account_pin VARCHAR(4) CHECK (account_pin BETWEEN '0000' AND '9999') NOT NULL UNIQUE
    );

    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table accounts;
    drop table account_pins;
    drop table user_passwords;

    drop type user_role;
    """;
}
