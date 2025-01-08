using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class FileCopyHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "FileCopy")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destPath = request.Current;

        var filecopy = new FileCopy(receiver, sourcePath, destPath);
        return filecopy;
    }
}
