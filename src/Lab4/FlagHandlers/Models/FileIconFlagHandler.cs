using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class FileIconFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--fi")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
            return null;

        string stringRequest = request.Current;

        if (stringRequest.Length != 1)
        {
            return null;
        }

        char fileIcon = stringRequest[0];

        var stringRequestFlag = new FileIconFlag(fileIcon);
        return stringRequestFlag;
    }
}
