using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.ResultTypes;

namespace Domain.Operations.Models;

public class CheckBalanceOperation : CommonOperation
{
    public override ExecuteResult Execute()
    {
        ExecutedTime = DateTime.Now;
        Receiver.ShowBalance();
        return new ExecuteResult.Success();
    }

    public CheckBalanceOperation(IAccount account) : base(account)
    {
        OperationType = "Check Balance";
    }

    public override ExecuteResult Undo()
    {
        return new ExecuteResult.Success();
    }
}
