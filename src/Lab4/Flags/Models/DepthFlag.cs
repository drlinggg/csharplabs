using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class DepthFlag : IFlag
{
    public uint Depth { get; init; }

    public DepthFlag(uint depth)
    {
        Depth = depth;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
