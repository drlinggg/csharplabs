using Domain.Accounts.Common;
using Domain.Operations.Common;

namespace Presentation.ParamHandlers.Common;

public interface IParamHandler
{
    public IParamHandler AddNext(IParamHandler paramHandler);

    public IOperation? Handle(IEnumerator<string> request, IAccount account);
}
