using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class ConnectHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "Connect")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        var connect = new Connect(receiver, path);
        return connect;
    }
}
