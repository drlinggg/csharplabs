using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class TreeListHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "TreeList")
            return Next?.Handle(request, receiver);

        var treelist = new TreeList(receiver);
        return treelist;
    }
}
