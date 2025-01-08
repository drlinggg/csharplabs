using Domain.Contracts.Accounts;
using Domain.Contracts.Users;
using Domain.Operations.Common;
using Domain.Services.Accounts;
using Presentation.ParamHandlers.Common;
using Presentation.ParamHandlers.Models;
using Presentation.Scenarios.Common;

namespace Presentation.Scenarios.Models;

public class AccountOperationScenario : IScenario
{
    private readonly IParamHandler paramHandler = new CheckBalanceHandler()
        .AddNext(new ShowHistoryHandler())
        .AddNext(new ReplenishmentHandler())
        .AddNext(new CashOutHandler());

    private readonly CurrentAccountManager _currentAccount;

    private readonly IUserService _userService;

    private readonly IAccountService _accountService;

    public AccountOperationScenario(CurrentAccountManager currentAccount, IAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
        _currentAccount = currentAccount;
    }

    public string Name { get; init; } = "Account Operations";

    public void Run()
    {
        System.Console.Clear();
        System.Console.WriteLine(Name);
        System.Console.WriteLine("Ready to input:\n1: Check Balance\n2: Replenishment X\n3: ShowHistory\n4: CashOut X");
        string? input = System.Console.ReadLine();
        if (input is not null && _currentAccount.Account is not null)
        {
            string[] words = input.Split(' ');
            IEnumerator<string> enumerator = words.AsEnumerable().GetEnumerator();
            enumerator.MoveNext();
            IOperation? operation = paramHandler.Handle(enumerator, _currentAccount.Account);

            if (operation is not null)
                operation.Execute();

            _accountService.UpdateAccount(
                    _currentAccount.Account.Id,
                    _currentAccount.Account.Amount,
                    _currentAccount.Account.Currency);

            Thread.Sleep(3000);
        }

        var next = new AccountOperationScenario(_currentAccount, _accountService, _userService);
        next.Run();
    }
}
