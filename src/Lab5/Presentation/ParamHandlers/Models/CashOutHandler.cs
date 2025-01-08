using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.Models;
using Presentation.ParamHandlers.Common;

namespace Presentation.ParamHandlers.Models;

public class CashOutHandler : CommonParamHandler
{
    public override IOperation? Handle(IEnumerator<string> request, IAccount account)
    {
        if (request.Current is not "CashOut")
            return Next?.Handle(request, account);
        if (request.MoveNext() is false)
            return null;

        uint amount = Convert.ToUInt32(request.Current);

        var operation = new CashOutOperation(account, amount);
        account.History.Add(operation);
        return operation;
    }
}
