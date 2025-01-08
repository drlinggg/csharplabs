using Domain.Accounts.Common;
using Domain.Operations.Common;

namespace Presentation.ParamHandlers.Common;

public abstract class CommonParamHandler : IParamHandler
{
    protected IParamHandler? Next { get; private set; }

    public IParamHandler AddNext(IParamHandler paramHandler)
    {
        if (Next is null)
        {
            Next = paramHandler;
        }
        else
        {
            Next.AddNext(paramHandler);
        }

        return this;
    }

    public abstract IOperation? Handle(IEnumerator<string> request, IAccount account);
}
