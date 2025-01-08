using Flags.Common;

namespace FlagHandlers.Common;

public interface IFlagHandler
{
    IFlagHandler AddNext(IFlagHandler handler);

    IFlag? Handle(IEnumerator<string> request);
}
