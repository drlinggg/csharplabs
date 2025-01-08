using Commands.Common;
using Commands.Models;
using Flags.Common;
using Flags.Models;
using FlagVisitors.Common;

namespace FlagVisitors.Models;

public class FlagModifierVisitor : IFlagVisitor
{
    private readonly Connect? _command;

    private readonly TreeList? _treelist;

    private readonly FileShow? _fileshow;

    public FlagModifierVisitor(Connect command)
    {
        _command = command;
    }

    public FlagModifierVisitor(TreeList treelist)
    {
        _treelist = treelist;
    }

    public FlagModifierVisitor(FileShow fileshow)
    {
        _fileshow = fileshow;
    }

    public void Visit(SystemFlag systemFlag)
    {
        if (_command != null)
        {
            _command.SetSystemMode(systemFlag.System);
        }
    }

    public void Visit(OutputFlag outputFlag)
    {
        if (_fileshow != null)
        {
            _fileshow.SetOutputMode(outputFlag.Output);
        }
    }

    public void Visit(DepthFlag depthFlag)
    {
        if (_treelist != null)
        {
            _treelist.SetDepthMode(depthFlag.Depth);
        }
    }

    public void Visit(DirIconFlag dirIconFlag)
    {
        if (_treelist != null)
        {
            _treelist.SetDirIconMode(dirIconFlag.DirIcon);
        }
    }

    public void Visit(FileIconFlag fileIconFlag)
    {
        if (_treelist != null)
        {
            _treelist.SetFileIconMode(fileIconFlag.FileIcon);
        }
    }

    public void Visit(IndentSymbolFlag indentSymbolFlag)
    {
        if (_treelist != null)
        {
            _treelist.SetIndentMode(indentSymbolFlag.IndentSymbol);
        }
    }

    public FlagModifierVisitor(ICommand other) { }

    public void Visit(IFlag other) { }
}
