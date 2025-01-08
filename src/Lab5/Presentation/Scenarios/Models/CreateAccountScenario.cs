using Domain.Accounts.Common;
using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Currencies.Models;
using Domain.Services.Accounts;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class CreateAccountScenario : IScenario
{
    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name { get; init; } = "Create Account";

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

            System.Console.WriteLine("Enter currency");
            string? currencyString = System.Console.ReadLine();

            if (name is not null && password is not null && currencyString is not null)
            {
                Enum.TryParse<Currency>(currencyString, out Currency currency);
                IAccount? acc = _accountService.CreateAccount(name, currency, password);
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
