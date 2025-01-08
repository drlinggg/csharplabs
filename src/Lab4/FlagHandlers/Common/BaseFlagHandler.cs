using Flags.Common;

namespace FlagHandlers.Common;

public abstract class BaseFlagHandler : IFlagHandler
{
    protected IFlagHandler? Next { get; private set; }

    public IFlagHandler AddNext(IFlagHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract IFlag? Handle(IEnumerator<string> request);
}
