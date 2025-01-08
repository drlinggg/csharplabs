using Commands.Common;
using FlagHandlers.Common;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class FileRemove : BaseCommand
{
    private readonly IFlagHandler? _handler = null;

    private readonly string _path;

    public override ExecuteResult Execute()
    {
        Receiver.FileRemove(_path);
        return new ExecuteResult.Success();
    }

    public FileRemove(IReceiver receiver, string path) : base(receiver)
    {
        _path = path;
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
