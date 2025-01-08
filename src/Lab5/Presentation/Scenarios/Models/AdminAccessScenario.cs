using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class AdminAccessScenario : IScenario
{
    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public AdminAccessScenario(IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name { get; init; } = "Admin Access";

    public void Run()
    {
        System.Console.WriteLine(Name);
        new AdminAccessScenario(_accountService, _userService).Run();
    }
}
