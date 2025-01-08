using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Extensions;
using Infastructure.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;
using Presentation.Scenarios.Models;

namespace Programs;

public static class Program
{
    public static void Main()
    {
        IServiceCollection collection = new ServiceCollection();

        collection.AddApplication()
                  .AddPresentation()
                  .AddInfastructureDataAccess(config =>
                                            {
                                                config.Host = "localhost";
                                                config.Port = 5432;
                                                config.Username = "postgres";
                                                config.Password = "postgres";
                                                config.Database = "postgres";
                                                config.SslMode = "Prefer";
                                            });

        IServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        scope.UseInfastructureDataAccess();

        IAccountService? accountService = scope.ServiceProvider.GetService<IAccountService>();
        IUserService? userService = scope.ServiceProvider.GetService<IUserService>();

        if (accountService is null || userService is null)
        {
            return;
        }

        var startScenario = new StartScenario(accountService, userService);

        while (true)
        {
            System.Console.Clear();
            startScenario.Run();
        }
    }
}
