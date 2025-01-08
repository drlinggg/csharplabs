using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class OutputFlag : IFlag
{
    public string Output { get; init; }

    public OutputFlag(string output)
    {
        Output = output;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
