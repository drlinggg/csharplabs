using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class FileShowHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "FileShow")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        var fileshow = new FileShow(receiver, sourcePath);
        return fileshow;
    }
}
