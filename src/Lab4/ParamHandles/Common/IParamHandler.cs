using Commands.Common;
using Receivers.Common;

namespace ParamHandlers.Common;

public interface IParamHandler
{
    public IParamHandler AddNext(IParamHandler paramHandler);

    public ICommand? Handle(IEnumerator<string> request, IReceiver receiver);
}
