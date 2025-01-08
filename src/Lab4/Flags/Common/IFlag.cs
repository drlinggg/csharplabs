using FlagVisitors.Common;

namespace Flags.Common;

public interface IFlag
{
    public void Accept(IFlagVisitor visitor);
}
