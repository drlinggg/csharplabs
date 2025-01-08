using Commands.Common;
using FlagHandlers.Common;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class FileRename : BaseCommand
{
    private readonly string _path;

    private readonly string _name;

    private readonly IFlagHandler? _handler = null;

    public override ExecuteResult Execute()
    {
        Receiver.FileRename(_path, _name);
        return new ExecuteResult.Success();
    }

    public FileRename(IReceiver receiver, string path, string name) : base(receiver)
    {
        _path = path;
        _name = name;
    }

    public override IFlag? Handle(IEnumerator<string> request)
    {
        if (_handler is null)
            return null;

        IFlag? flag = _handler.Handle(request);

        if (flag != null)
        {
            var visitor = new FlagModifierVisitor(this);
            flag.Accept(visitor);
        }

        return flag;
    }
}
