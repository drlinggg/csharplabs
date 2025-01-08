using Commands.Common;
using FlagHandlers.Models;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class Connect : BaseCommand
{
    private readonly string _address;

    private readonly SystemFlagHandler _handler = new SystemFlagHandler();

    private string _systemMode = "local";

    public override ExecuteResult Execute()
    {
        switch (_systemMode)
        {
            case "local":
                Receiver.Connect(_address, _systemMode);
                return new ExecuteResult.Success();

            default:
                return new ExecuteResult.UnknowFailure();
        }
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

    public Connect(IReceiver receiver, string address) : base(receiver)
    {
        _address = address;
    }

    public void SetSystemMode(string systemMode)
    {
        _systemMode = systemMode;
    }
}
