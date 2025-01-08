using Flags.Models;

namespace FlagVisitors.Common;

public interface IFlagVisitor
{
    public void Visit(SystemFlag systemFlag);

    public void Visit(OutputFlag outputFlag);

    public void Visit(DepthFlag depthFlag);

    public void Visit(FileIconFlag fileIconFlag);

    public void Visit(DirIconFlag dirIconFlag);

    public void Visit(IndentSymbolFlag indentSymbolFlag);
}
