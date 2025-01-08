using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Contracts.Users.ResultTypes;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class AdminLoginScenario : IScenario
{
    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public AdminLoginScenario(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name { get; init; } = "Admin login";

    public void Run()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine(Name);

            System.Console.WriteLine("Enter your username");
            string? name = System.Console.ReadLine();

            System.Console.WriteLine("Enter your password");
            string? password = System.Console.ReadLine();

            if (name is not null && password is not null)
            {
                LoginResult res = _userService.LoginAsRoot(name, password);
                if (res is not LoginResult.Success)
                    continue;

                var next = new AdminAccessScenario(_accountService, _userService);
                next.Run();
            }
        }
    }
}
