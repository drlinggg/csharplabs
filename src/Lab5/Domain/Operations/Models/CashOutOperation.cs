using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.ResultTypes;

namespace Domain.Operations.Models;

public class CashOutOperation : CommonOperation
{
    private readonly uint amount;

    public override ExecuteResult Execute()
    {
        ExecutedTime = DateTime.Now;
        Receiver.CashOut(amount);
        return new ExecuteResult.Success();
    }

    public CashOutOperation(IAccount account, uint summ) : base(account)
    {
        OperationType = "Cash out";
        amount = summ;
    }

    public override ExecuteResult Undo()
    {
        return new ExecuteResult.Success();
    }
}
