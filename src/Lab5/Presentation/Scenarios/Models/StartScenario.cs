using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class StartScenario : IScenario
{
    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public string Name { get; init; } = "Start Scenario";

    public StartScenario(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public void Run()
    {
        System.Console.Clear();
        System.Console.WriteLine("Choose scenario:\n1:Login User\n2:Login Admin");
        string? input = System.Console.ReadLine();

        if (input is not null)
        {
            switch (input)
            {
                case "Login User":
                    var next = new UserLoginScenario(_userService, _accountService);
                    next.Run();
                    break;

                case "Login Admin":
                    var nextScenario = new AdminLoginScenario(_accountService, _userService);
                    nextScenario.Run();
                    break;
            }
        }
    }
}
