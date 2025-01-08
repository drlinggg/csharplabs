using Commands.Common;
using Commands.Models;
using ParamHandlers.Common;
using Receivers.Common;

namespace ParamHandlers.Models;

public class FileRenameHandler : BaseParamHandler
{
    public override ICommand? Handle(IEnumerator<string> request, IReceiver receiver)
    {
        if (request.Current is not "FileRename")
            return Next?.Handle(request, receiver);
        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return null;

        string name = request.Current;

        var filerename = new FileRename(receiver, sourcePath, name);
        return filerename;
    }
}
