using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class FileMoveHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "FileMove")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destPath = request.Current;

        var filemove = new FileMove(receiver, sourcePath, destPath);
        return filemove;
    }
}
