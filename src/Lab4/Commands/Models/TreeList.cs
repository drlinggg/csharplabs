using Commands.Common;
using FlagHandlers.Common;
using FlagHandlers.Models;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class TreeList : BaseCommand
{
    private readonly IFlagHandler _handler = new DepthFlagHandler()
        .AddNext(new FileIconFlagHandler())
        .AddNext(new DirIconFlagHandler())
        .AddNext(new IndentSymbolFlagHandler());

    private uint _depth = 1;

    private char _fileIcon = char.MinValue;

    private char _dirIcon = char.MinValue;

    private char _indentSymbol = ' ';

    public override ExecuteResult Execute()
    {
        Receiver.TreeList(_depth, _fileIcon, _dirIcon, _indentSymbol);
        return new ExecuteResult.Success();
    }

    public TreeList(IReceiver receiver) : base(receiver) { }

    public void SetDepthMode(uint depth)
    {
        _depth = depth;
    }

    public void SetFileIconMode(char fileIcon)
    {
        _fileIcon = fileIcon;
    }

    public void SetDirIconMode(char dirIcon)
    {
        _dirIcon = dirIcon;
    }

    public void SetIndentMode(char indentSymbol)
    {
        _indentSymbol = indentSymbol;
    }

    public override IFlag? Handle(IEnumerator<string> request)
    {
        IFlag? flag = _handler.Handle(request);

        if (flag != null)
        {
            var visitor = new FlagModifierVisitor(this);
            flag.Accept(visitor);
        }

        return flag;
    }
}
