using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.Models;
using Presentation.ParamHandlers.Common;

namespace Presentation.ParamHandlers.Models;

public class ReplenishmentHandler : CommonParamHandler
{
    public override IOperation? Handle(IEnumerator<string> request, IAccount account)
    {
        if (request.Current is not "Replenishment")
            return Next?.Handle(request, account);
        if (request.MoveNext() is false)
            return null;

        uint amount = Convert.ToUInt32(request.Current);

        var operation = new ReplenishmentOperation(account, amount);
        account.History.Add(operation);
        return operation;
    }
}
