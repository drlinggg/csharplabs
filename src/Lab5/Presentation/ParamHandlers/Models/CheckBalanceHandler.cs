using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.Models;
using Presentation.ParamHandlers.Common;

namespace Presentation.ParamHandlers.Models;

public class CheckBalanceHandler : CommonParamHandler
{
    public override IOperation? Handle(IEnumerator<string> request, IAccount account)
    {
        if (request.Current is not "CheckBalance")
            return Next?.Handle(request, account);

        var operation = new CheckBalanceOperation(account);
        account.History.Add(operation);
        return operation;
    }
}
