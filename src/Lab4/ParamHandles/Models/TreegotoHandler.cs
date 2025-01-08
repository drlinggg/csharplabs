using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class TreegotoHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "TreeGoto")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        var treegoto = new TreeGoto(receiver, path);
        return treegoto;
    }
}
