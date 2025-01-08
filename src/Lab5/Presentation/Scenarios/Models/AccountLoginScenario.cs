using Domain.Accounts.Common;
using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Services.Accounts;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class AccountLoginScenario : IScenario
{
    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public string Name { get; init; } = "Account login";

    public AccountLoginScenario(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public void Run()
    {
        while (true)
        {
            System.Console.Clear();

            System.Console.WriteLine(Name);

            System.Console.WriteLine("Enter your username");
            string? name = System.Console.ReadLine();

            System.Console.WriteLine("Enter your pin");
            string? password = System.Console.ReadLine();

            if (name is not null && password is not null)
            {
                IAccount? acc = _accountService.GetAccount(name, password);

                if (acc is null)
                {
                    continue;
                }

                var cac = new CurrentAccountManager();
                cac.Account = acc;
                var next = new AccountOperationScenario(cac, _accountService, _userService);
                next.Run();
            }
        }
    }
}
