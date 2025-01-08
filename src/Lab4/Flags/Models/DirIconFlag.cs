using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class DirIconFlag : IFlag
{
    public char DirIcon { get; init; }

    public DirIconFlag(char dirIcon)
    {
        DirIcon = dirIcon;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
