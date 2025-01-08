using Domain.Accounts.Common;
using Domain.Operations.ResultTypes;

namespace Domain.Operations.Common;

public abstract class CommonOperation : IOperation
{
    public string OperationType { get; init; } = "NONE";

    protected IAccount Receiver { get; init; }

    protected DateTime ExecutedTime { get; set; }

    public abstract ExecuteResult Execute();

    protected CommonOperation(IAccount receiver)
    {
        Receiver = receiver;
    }

    public string FancyPrint()
    {
        string time = ExecutedTime.ToString("dd/MM/yyyy");
        return time + '\n' + OperationType;
    }

    public abstract ExecuteResult Undo();
}
