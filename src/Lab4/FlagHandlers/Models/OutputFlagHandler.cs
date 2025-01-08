using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class OutputFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--m")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
            return null;

        string output = request.Current;

        var outputFlag = new OutputFlag(output);
        return outputFlag;
    }
}
