using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.ResultTypes;

namespace Domain.Operations.Models;

public class ReplenishmentOperation : CommonOperation
{
    private readonly uint amount;

    public override ExecuteResult Execute()
    {
        ExecutedTime = DateTime.Now;
        Receiver.Replenishment(amount);
        return new ExecuteResult.Success();
    }

    public ReplenishmentOperation(IAccount account, uint summ) : base(account)
    {
        amount = summ;
        OperationType = "Replenishment";
    }

    public override ExecuteResult Undo()
    {
        return new ExecuteResult.Success();
    }
}
