using Commands.Common;
using FlagHandlers.Models;
using Flags.Common;
using FlagVisitors.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Commands.Models;

public class FileShow : BaseCommand
{
    private readonly string _path;

    private readonly OutputFlagHandler _handler = new OutputFlagHandler();

    private string _outputMode = "console";

    public override ExecuteResult Execute()
    {
        Receiver.FileShow(_path, _outputMode);
        return new ExecuteResult.Success();
    }

    public FileShow(IReceiver receiver, string path) : base(receiver)
    {
        _path = path;
    }

    public void SetOutputMode(string outputMode)
    {
        _outputMode = outputMode;
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
