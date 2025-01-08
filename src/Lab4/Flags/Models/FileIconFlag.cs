using Flags.Common;
using FlagVisitors.Common;

namespace Flags.Models;

public class FileIconFlag : IFlag
{
    public char FileIcon { get; init; }

    public FileIconFlag(char fileIcon)
    {
        FileIcon = fileIcon;
    }

    public void Accept(IFlagVisitor visitor)
    {
        visitor.Visit(this);
    }
}
