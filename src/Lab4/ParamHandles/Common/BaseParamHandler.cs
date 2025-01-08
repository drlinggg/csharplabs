using Commands.Common;
using Receivers.Common;

namespace ParamHandlers.Common;

public abstract class BaseParamHandler : IParamHandler
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

    public abstract ICommand? Handle(IEnumerator<string> request, IReceiver receiver);
}
