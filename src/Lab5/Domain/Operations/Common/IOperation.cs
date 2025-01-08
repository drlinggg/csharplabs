using Domain.Operations.ResultTypes;

namespace Domain.Operations.Common;

public interface IOperation
{
    public string OperationType { get; init; }

    public ExecuteResult Execute();

    public string FancyPrint();

    public ExecuteResult Undo();
}
