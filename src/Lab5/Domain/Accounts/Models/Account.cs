using Domain.Accounts.Common;
using Domain.Currencies.Models;
using Domain.Operations.Common;
using System.Collections.ObjectModel;

namespace Domain.Accounts.Models;

public class Account : IAccount
{
    public long Id { get; init; }

    public Currency Currency { get; set; }

    public long Amount { get; set; } = 0;

    public Collection<CommonOperation> History { get; init; } = [];

    public Account(long id, Currency currency, long amount)
    {
        Id = id;
        this.Currency = currency;
        this.Amount = amount;
    }

    public void CashOut(uint amount)
    {
        if (amount > this.Amount)
        {
            return;
        }

        this.Amount -= amount;
        Console.WriteLine(Amount);
    }

    public void Replenishment(uint amount)
    {
        this.Amount += amount;
        Console.WriteLine(Amount);
    }

    public void ShowHistory()
    {
        string output = string.Empty;
        foreach (CommonOperation operation in History)
        {
            output += operation.FancyPrint() + '\n';
        }

        Console.WriteLine(output);
    }

    public void ShowBalance()
    {
        Console.WriteLine(Amount);
    }
}
