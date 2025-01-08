using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class DisconnectHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "Disconnect")
            return Next?.Handle(request, receiver);

        var disconnect = new Disconnect(receiver);
        return disconnect;
    }
}
