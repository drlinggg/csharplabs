using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.ResultTypes;

namespace Domain.Operations.Models;

public class ShowHistoryOperation : CommonOperation
{
    public override ExecuteResult Execute()
    {
        ExecutedTime = DateTime.Now;
        Receiver.ShowHistory();
        return new ExecuteResult.Success();
    }

    public ShowHistoryOperation(IAccount account) : base(account)
    {
        OperationType = "Show History";
    }

    public override ExecuteResult Undo()
    {
        return new ExecuteResult.Success();
    }
}
