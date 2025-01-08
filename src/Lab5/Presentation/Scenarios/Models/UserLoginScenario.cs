using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Contracts.Users.ResultTypes;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class UserLoginScenario : IScenario
{
    public string Name { get; init; } = "User login";

    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public UserLoginScenario(IUserService userService, IAccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
    }

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
                LoginResult res = _userService.Login(name, password);

                if (res is LoginResult.Success)
                {
                    var next = new AccountLoginScenario(_accountService, _userService);
                    next.Run();
                }
            }
        }
    }
}
