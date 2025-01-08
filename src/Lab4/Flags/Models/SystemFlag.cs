using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class SystemFlag : IFlag
{
    public string System { get; init; }

    public SystemFlag(string system)
    {
        System = system;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
