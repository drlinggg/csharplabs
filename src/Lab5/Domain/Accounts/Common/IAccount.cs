using Domain.Currencies.Models;
using Domain.Operations.Common;
using System.Collections.ObjectModel;

namespace Domain.Accounts.Common;

public interface IAccount
{
    public long Id { get; init; }

    public Currency Currency { get; set; }

    public long Amount { get; set; }

    public void ShowBalance();

    public Collection<CommonOperation> History { get; init; }

    public void CashOut(uint amount);

    public void Replenishment(uint amount);

    public void ShowHistory();
}
