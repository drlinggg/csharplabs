using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class DepthFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--d")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
        {
            return null;
        }

        uint depth = Convert.ToUInt32(request.Current);

        var depthFlag = new DepthFlag(depth);
        return depthFlag;
    }
}
