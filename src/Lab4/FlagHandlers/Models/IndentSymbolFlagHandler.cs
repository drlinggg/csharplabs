using FlagHandlers.Common;
using Flags.Common;
using Flags.Models;

namespace FlagHandlers.Models;

public class IndentSymbolFlagHandler : BaseFlagHandler
{
    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "--ii")
            return Next?.Handle(request);
        if (request.MoveNext() is false)
            return null;

        string stringRequest = request.Current;

        if (stringRequest.Length != 1)
        {
            return null;
        }

        char indentSymbol = stringRequest[0];

        var indentSymbolFlag = new IndentSymbolFlag(indentSymbol);
        return indentSymbolFlag;
    }
}
