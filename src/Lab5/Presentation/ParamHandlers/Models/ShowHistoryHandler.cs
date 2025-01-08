using Domain.Accounts.Common;
using Domain.Operations.Common;
using Domain.Operations.Models;
using Presentation.ParamHandlers.Common;

namespace Presentation.ParamHandlers.Models;

public class ShowHistoryHandler : CommonParamHandler
{
    public override IOperation? Handle(IEnumerator<string> request, IAccount account)
    {
        if (request.Current is not "ShowHistory")
            return Next?.Handle(request, account);

        var operation = new ShowHistoryOperation(account);
        account.History.Add(operation);
        return operation;
    }
}
