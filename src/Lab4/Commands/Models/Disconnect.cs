using Commands.Common;
using FlagHandlers.Common;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class Disconnect : BaseCommand
{
    private readonly IFlagHandler? _handler = null;

    public override ExecuteResult Execute()
    {
        Receiver.Disconnect();
        return new ExecuteResult.Success();
    }

    public Disconnect(IReceiver receiver) : base(receiver) { }

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
