using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class IndentSymbolFlag : IFlag
{
    public char IndentSymbol { get; init; }

    public IndentSymbolFlag(char indentSymbol)
    {
        IndentSymbol = indentSymbol;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
