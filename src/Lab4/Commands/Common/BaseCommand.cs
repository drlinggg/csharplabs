using Flags.Common;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Common;

public abstract class BaseCommand : ICommand
{
    protected IReceiver Receiver { get; init; }

    public abstract ExecuteResult Execute();

    public abstract IFlag? Handle(IEnumerator<string> request);

    protected BaseCommand(IReceiver receiver)
    {
        Receiver = receiver;
    }
}
