using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class DirIconFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--di")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
            return null;

        string stringRequest = request.Current;

        if (stringRequest.Length != 1)
        {
            return null;
        }

        char dirIcon = stringRequest[0];

        var stringRequestFlag = new DirIconFlag(dirIcon);
        return stringRequestFlag;
    }
}
