using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class FileRemoveHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "FileRemove")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        var fileremove = new FileRemove(receiver, sourcePath);
        return fileremove;
    }
}
