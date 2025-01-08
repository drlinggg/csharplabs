using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class SystemFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--s")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
            return null;

        string system = request.Current;

        var systemFlag = new SystemFlag(system);
        return systemFlag;
    }
}
